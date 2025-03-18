

namespace CARAI.API.Controllers
{
    using CARAI.Application.Commands.RequestToMechanic;
    using CARAI.Application.Commands.User;
    using CARAI.Domain.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    [Route("/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IMediator mediator, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterAccountCommand registerAccountCommand)
        {
            var user = await mediator.Send(registerAccountCommand);

            // Step 2: Set email and username
            await userManager.SetEmailAsync(user, registerAccountCommand.Email);
            await userManager.SetUserNameAsync(user, registerAccountCommand.Email);

            // Step 3: Create the user in the system
            IdentityResult result = await userManager.CreateAsync(user, registerAccountCommand.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "User registration failed", details = result.Errors });
            }

            // Step 4: Generate JWT Token after user is created
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) // Optional, for user ID
            };

            var key = Encoding.UTF8.GetBytes("your-secure-key-that-is-at-least-16-bytes"); // Make sure to use a secure key
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = user.Id;

            return Ok(new { Token = tokenString });
        }



        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LogUserCommand logUserCommand)
        {
            ApplicationUser user = await mediator.Send(logUserCommand);

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            if (user == null || passwordHasher.VerifyHashedPassword(user, user.PasswordHash, logUserCommand.Password) == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                };

            // Create signing credentials with a symmetric key (make sure to keep the secret key safe)
            var key = Encoding.UTF8.GetBytes("your-secure-key-that-is-at-least-16-bytes"); // 128 bits
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            // Generate the JWT token (set expiration and other token parameters)
            var token = new JwtSecurityToken(
                issuer: "YourIssuer", // e.g., "MyApp"
                audience: "YourAudience", // e.g., "MyAppClients"
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expiration time
                signingCredentials: creds
            );

            // Return the token as part of the response
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = user.Id;

            return Ok(new { Token = tokenString });
        }

        [HttpPost("createRequest")]
        public async Task<ActionResult> CreateRequestToMechanic(CreateRequestToMechanicCommand mechanicCommand)
        {
            if (GetTokenAndIdIfExists() == null)
            {
                return BadRequest();
            }

            bool isSuccesful = await  mediator.Send(mechanicCommand);

            if (isSuccesful)
            {
                return Ok();
            }

            return BadRequest();    
        }


        private string GetTokenAndIdIfExists()
        {
            var token = Request.Headers["Authorization"].ToString();


            if (token == null)
            {
                return null;
            }



            string id = token.Remove(0, 6).Trim();

            return id;
        }

    }
}

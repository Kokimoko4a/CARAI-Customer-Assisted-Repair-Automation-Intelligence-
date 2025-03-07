

namespace CARAI.API.Controllers
{
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
        public async Task<ActionResult> Index([FromBody] RegisterAccountCommand registerAccountCommand)
        {
            var user = await  mediator.Send(registerAccountCommand);

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
    }
}


namespace CARAI
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using CARAI.Infrastructure.Persistence;
    using CARAI.Domain.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using CARAI.Application.Commands.User;
    using CARAI.Application.Interfaces;

    //using Microsoft.AspNetCore.Authentication.JwtBearer;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()  // Allow any origin (you can specify one if needed)
                          .AllowAnyHeader()   // Allow any headers
                          .AllowAnyMethod();  // Allow any HTTP method (GET, POST, etc.)
                });
            });

            // Add services to the container.

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<CARAIDbContext>(options =>
                options.UseSqlServer(connectionString));//registers the dbcontext



            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;



                // Disable account confirmation requirement
            })
                  .AddRoles<IdentityRole<Guid>>()
                  .AddEntityFrameworkStores<CARAIDbContext>();//add the identity



            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(RegisterAccountCommand).Assembly); // Register handlers from the current assembly
            });


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false; // For development (use HTTPS in production)
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = "YourIssuer", // Replace with your issuer
                   ValidAudience = "YourAudience", // Replace with your audience
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secure-key-that-is-at-least-16-bytes")) // Use a secret key for signing
               };
           });//to use the jwt


            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRequestToMechanicRepository, RequestToMechanicRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("AllowAll");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using Forum.Contracts;
using Forum.Data;
using Forum.Models.Identity;
using Forum.Repositories;
using Forum.Service.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;

namespace ForumAPI
{
    public static class MiddlwareExtensions
    {


        public static void AddDBContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection")));
        }
                public static void ConfigureJwtOptions(this WebApplicationBuilder builder) => builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

        public static void AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            JwtOptions jwtOptions = new();

            var secret = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Secret");
            var issuer = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Issuer");
            var audience = builder.Configuration.GetValue<string>("ApiSettings:JwtOptions:Audience");
            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer =  issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)

                };

            });
        }

        public static void ConfigurJwtOptions(this WebApplicationBuilder builder) => builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
      

        public static void AddScopedServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IForumRepository, ForumRepository>();
            builder.Services.AddScoped<IForumServices, ForumService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        }

        public static void AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }

        public static void AddAuthorziation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("DoubleRolePolicy", policy =>
                {
                    policy.RequireRole("Admin", "User");
                });

                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("Admin");
                });

                options.AddPolicy("User", policy =>
                {
                    policy.RequireRole("User");
                });
            });
        }

        public static void AddEndpointsApiExplorer(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
        }

        public static void AddSwaggerGen(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
        }

        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: builder.Configuration.GetValue<string>("Cors:AllowOrigin"), policy =>
                {
                    policy.AllowAnyOrigin();
                });
            });
        }
    }
}

//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using SchoolProject.Domain.Entities.Identity;
//using SchoolProject.Domain.Helpers;
//using SchoolProject.Infrustructure.Domain;
//using System.Text;

//// eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyTmFtZSI6IkJhc2VtT21hciIsIlBob25lTnVtYmVyIjoiOTEyMzIzOTIiLCJFbWFpbCI6ImJhc2VtQGdtYWlsLmNvbSIsImV4cCI6MTcxMjQzNDk0MCwiaXNzIjoic2Nob29sUHJvZWpjdCIsImF1ZCI6ImFueW9uZSJ9.SAd8x3MNhS5mQSP8u1EKOn9ujxaVMGGCUBL4YDj0Das

//namespace SchoolProject.Infrustructure
//{
//    public static class ServiceRegistration
//    {
//        public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
//        {
//            services.AddIdentity<User, IdentityRole<int>>(options =>
//            {

//                // Default Password settings.
//                options.Password.RequireDigit = true;
//                options.Password.RequireLowercase = true;
//                options.Password.RequireNonAlphanumeric = true;
//                options.Password.RequireUppercase = true;
//                options.Password.RequiredLength = 6;
//                options.Password.RequiredUniqueChars = 1;


//                // Default User settings.
//                options.User.AllowedUserNameCharacters =
//                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//                options.User.RequireUniqueEmail = false;

//                // Default Lockout settings.
//                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//                options.Lockout.MaxFailedAccessAttempts = 5;
//                options.Lockout.AllowedForNewUsers = true;

//            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


//            // Authentication Jwt
//            var jwt = new JwtConfig();
//            configuration.GetSection("jwtConfigration").Bind(jwt); // we need to install jwtBearer
//            services.AddSingleton(jwt);

//            // this following code we need it in any project
//            services.AddAuthentication(x =>
//            {
//                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            })
//           .AddJwtBearer(x =>
//           {
//               x.RequireHttpsMetadata = false;
//               x.SaveToken = true;
//               x.TokenValidationParameters = new TokenValidationParameters
//               {
//                   ValidateIssuer = jwt.ValidateIssuer,
//                   ValidIssuers = new[] { jwt.Issuer },
//                   ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
//                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt.Secret)),
//                   ValidAudience = jwt.Audience,
//                   ValidateAudience = jwt.ValidateAudience,
//                   ValidateLifetime = jwt.ValidateLifeTime,

//               };
//           });

//            // this shceme just for swagger (Testing Api) ( i copied from api-demo route)
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiDemo", Version = "v1" });
//                c.EnableAnnotations();

//                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//                {
//                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
//                    Name = "Authorization",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = JwtBearerDefaults.AuthenticationScheme
//                });


//                var securitySchema = new OpenApiSecurityScheme
//                {
//                    Description = "JWT Authorization header using the Bearer scheme.",
//                    Name = "Authoirzation",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = "bearer",
//                    Reference = new OpenApiReference
//                    {
//                        Type = ReferenceType.SecurityScheme,
//                        Id = "bearer"
//                    }
//                };

//                c.AddSecurityDefinition("bearer", securitySchema);

//                var securityRequirement = new OpenApiSecurityRequirement
//                {
//                    {
//                        securitySchema,
//                        new [] {"bearer"}
//                    }
//                };

//                c.AddSecurityRequirement(securityRequirement);
//            });
//            return services;
//        }
//    }
//}


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Infrustructure.Domain;
using System.Text;

namespace SchoolProject.Infrustructure
{

    // use this don't user above one 
    // IMPORTATN NOTE WHEN YOU COPY JWT CONFIGRATINO NEXT TIME DON'T USE ONE ON STACKOVERFLOW USE ONE YOU USED BEFORE
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole<int>>(option =>
            {
                // Password settings.
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //JWT Authentication
            var jwtSettings = new JwtConfig();
            // var emailSettings = new EmailSettings();
            configuration.GetSection("jwtConfigration").Bind(jwtSettings);
            // configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSingleton(jwtSettings);
            // services.AddSingleton(emailSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = jwtSettings.ValidateIssuer,
                   ValidIssuers = new[] { jwtSettings.Issuer },
                   ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                   ValidAudience = jwtSettings.Audience,
                   ValidateAudience = jwtSettings.ValidateAudience,
                   ValidateLifetime = jwtSettings.ValidateLifeTime,
               };

               x.RequireHttpsMetadata = false;
           });


            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Project", Version = "v1" });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
            }
           });
            });

            //services.AddAuthorization(option =>
            //{
            //    option.AddPolicy("CreateStudent", policy =>
            //    {
            //        policy.RequireClaim("Create Student", "True");
            //    });
            //    option.AddPolicy("DeleteStudent", policy =>
            //    {
            //        policy.RequireClaim("Delete Student", "True");
            //    });
            //    option.AddPolicy("EditStudent", policy =>
            //    {
            //        policy.RequireClaim("Edit Student", "True");
            //    });
            //});



            return services;
        }
    }
}

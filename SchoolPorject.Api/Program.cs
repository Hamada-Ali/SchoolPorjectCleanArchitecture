using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.Middleware;
using SchoolProject.Infrustructure;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Services;
using System.Globalization;

namespace SchoolPorject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // connection to sql server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
            });
            //builder.Services.AddIdentity

            #region Localization


            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("ar-EG")
            };

                options.DefaultRequestCulture = new RequestCulture("ar-EG");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });



            #endregion

            #region Dependency injection

            builder.Services.AddInfrastructureDependencies()
                        .AddServiceDependencies()
                        .AddCoreDependency()
                        .AddServiceRegistration();
            #endregion


            #region CORS

            var cors = "_cors";
            builder.Services.AddCors(options =>
            {

                options.AddPolicy(name: "Allow_specification",
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowAnyOrigin();
                        //policy.AllowCredentials();
                    });
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // localization service & middleware
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMiddleware<ErrorHandlerMiddleware>(); // this is a middleware not a service (custome middleware)

            app.UseHttpsRedirection();

            app.UseCors(cors); // using our variable

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}







using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.AuthServices.Implementation;
using SchoolProject.Services.AuthServices.Interface;
using SchoolProject.Services.Implementation;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services
{
    public static class ModuleServiceDependencies
    {
        // extenstion method
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailsService, EmailsService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            return services;
        }
    }
}

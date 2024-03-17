using Microsoft.Extensions.DependencyInjection;
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
            return services;
        }
    }
}

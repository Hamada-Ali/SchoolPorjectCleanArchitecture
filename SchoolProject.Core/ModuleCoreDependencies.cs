using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Validation_Behaviors;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependencies
    {
        // related to mediator dependency injection 

        public static IServiceCollection AddCoreDependency(this IServiceCollection services)
        {

            // Mediator configration 
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //automapper configration
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }

    }
}

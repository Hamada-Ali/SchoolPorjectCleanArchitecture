using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Domain.Entities.Views;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Interface.Procedures;
using SchoolProject.Infrustructure.Interface.Views;
using SchoolProject.Infrustructure.Repositories;
using SchoolProject.Infrustructure.Repositories.Procedures;
using SchoolProject.Infrustructure.Repositories.Views;

namespace SchoolProject.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        // extenstion method
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRespository, DepartmentRespository>();
            services.AddTransient<IInstrctorRespository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            // views
            services.AddTransient<IViewRepository<ViewDepartment>, ViewDepartmentRepository>();

            // procedures
            services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();

            return services;
        }
    }
}

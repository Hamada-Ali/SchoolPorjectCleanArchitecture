using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Repositories;

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
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}

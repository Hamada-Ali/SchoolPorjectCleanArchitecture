using SchoolProject.Infrustructure.InfrastructureBases;

namespace SchoolProject.Infrustructure.Interface.Views
{
    public interface IViewRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
    }
}

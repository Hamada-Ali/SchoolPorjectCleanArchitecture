using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities.Views;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface.Views;

namespace SchoolProject.Infrustructure.Repositories.Views
{
    public class ViewDepartmentRepository : GenericRepositoryAsync<ViewDepartment>, IViewRepository<ViewDepartment>
    {
        private DbSet<ViewDepartment> _viewDepartments;

        public ViewDepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _viewDepartments = context.Set<ViewDepartment>();
        }
    }
}

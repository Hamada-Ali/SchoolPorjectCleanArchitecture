using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;

namespace SchoolProject.Infrustructure.Repositories
{
    public class DepartmentRespository : GenericRepositoryAsync<Department>, IDepartmentRespository
    {
        public DbSet<Department> departments { get; set; }
        public DepartmentRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
            departments = dbContext.Set<Department>();
        }
    }
}

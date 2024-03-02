using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;

namespace SchoolProject.Infrustructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstrctorRespository
    {
        private DbSet<Instructor> instructors;
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;

namespace SchoolProject.Infrustructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstrctorRespository
    {
        private DbSet<Instructor> _instructorsRepository;
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _instructorsRepository = dbContext.Set<Instructor>();
        }

        public async Task<List<Instructor>> GetInstructorsAsync()
        {
            return await _instructorsRepository.Include(x => x.DID).ToListAsync();
        }
    }
}

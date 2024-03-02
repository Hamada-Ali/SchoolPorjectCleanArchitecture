using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;

namespace SchoolProject.Infrustructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        private DbSet<Subjects> subjects;

        public SubjectRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            subjects = dbcontext.Set<Subjects>();
        }

    }
}

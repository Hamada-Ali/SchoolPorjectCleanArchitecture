using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.InfrastructureBases;
using SchoolProject.Infrustructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>,  IStudentRepository
    {
        private readonly DbSet<Student> _studentsRepository; // replace for _context.student

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _studentsRepository = context.Set<Student>();
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentsRepository.Include(x => x.Department).ToListAsync();
        }
    }
}

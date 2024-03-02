using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Interface
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentsAsync();
    }
}

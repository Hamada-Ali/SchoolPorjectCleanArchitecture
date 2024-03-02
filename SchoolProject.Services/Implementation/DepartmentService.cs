using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRespository _departmentRespository;

        public DepartmentService(IDepartmentRespository departmentRespository)
        {
            _departmentRespository = departmentRespository;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRespository.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                           .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                                                           .Include(x => x.Students)
                                                           .Include(x => x.Instructors)
                                                           .Include(x => x.Instructor).FirstOrDefaultAsync();

            return department;
        }
    }
}

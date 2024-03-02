using SchoolProject.Domain.Entities;

namespace SchoolProject.Services.Interface
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
    }
}

using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Entities.Procedures;
using SchoolProject.Domain.Entities.Views;

namespace SchoolProject.Services.Interface
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
        public Task<bool> IsDepartmentExist(int id);
        public Task<List<ViewDepartment>> GetViewDepartmentData();
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParams para);

    }
}

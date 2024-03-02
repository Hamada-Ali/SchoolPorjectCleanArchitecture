using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helpers;

namespace SchoolProject.Services.Interface
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public IQueryable<Student> GetStudentsQueryable();
        public IQueryable<Student> GetStudentsByDepartmentIdQuerable(int DID);
        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderyingEnum orderyingEnum, string search);
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(int id, string name);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
    }
}

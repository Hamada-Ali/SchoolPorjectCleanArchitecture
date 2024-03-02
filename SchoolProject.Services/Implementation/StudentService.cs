using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helpers;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Implementation
{


    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<string> AddAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();

            try
            {

                await _studentRepository.DeleteAsync(student);

                await trans.CommitAsync();

                return "Success";

            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "failed";
            }
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderyingEnum orderyingEnum, string search)
        {
            var queryable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();

            if (search != null) queryable = queryable.Where(x => x.NameEn.Contains(search) || x.Address.Contains(search));

            switch (orderyingEnum)
            {
                case StudentOrderyingEnum.StudId:
                    queryable = queryable.OrderBy(x => x.StudId);
                    break;
                case StudentOrderyingEnum.Address:
                    queryable = queryable.OrderBy(x => x.Address);
                    break;
                case StudentOrderyingEnum.name:
                    queryable = queryable.OrderBy(x => x.NameEn);
                    break;
                case StudentOrderyingEnum.DepartmentName:
                    queryable = queryable.OrderBy(x => x.Department.DNameEn);
                    break;
                default:
                    queryable = queryable.OrderBy(x => x.StudId);
                    break;
            }

            return queryable;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                .Include(x => x.Department)
                                .Where(x => x.StudId == id)
                                .FirstOrDefault();

            return student;
        }

        public IQueryable<Student> GetStudentsByDepartmentIdQuerable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(DID)).AsQueryable();

        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public async Task<bool> IsNameExist(string name)
        {
            var std = _studentRepository.GetTableNoTracking().Where(x => x.NameEn == name).FirstOrDefault();

            if (std != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNameExistExcludeSelf(int id, string name)
        {
            var std = await _studentRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(name) & !x.StudId.Equals(id)).FirstOrDefaultAsync();

            if (std != null)
            {
                return true;
            }
            return false;
        }
    }
}

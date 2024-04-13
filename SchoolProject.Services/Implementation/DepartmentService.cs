using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Entities.Procedures;
using SchoolProject.Domain.Entities.Views;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Interface.Procedures;
using SchoolProject.Infrustructure.Interface.Views;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRespository _departmentRespository;
        private readonly IViewRepository<ViewDepartment> _viewRepository;
        private readonly IDepartmentStudentCountProcRepository _departmentStudentCountProcRepository;

        public DepartmentService(IDepartmentRespository departmentRespository, IViewRepository<ViewDepartment> viewRepository,
            IDepartmentStudentCountProcRepository departmentStudentCountProcRepository)
        {
            _departmentRespository = departmentRespository;
            _viewRepository = viewRepository;
            _departmentStudentCountProcRepository = departmentStudentCountProcRepository;
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

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParams para)
        {
            return await _departmentStudentCountProcRepository.GetDepartmentStudentCountProcs(para);
        }

        public async Task<List<ViewDepartment>> GetViewDepartmentData()
        {
            var viewDepartment = await _viewRepository.GetTableNoTracking().ToListAsync();
            return viewDepartment;
        }

        public async Task<bool> IsDepartmentExist(int id)
        {
            var dept = _departmentRespository.GetTableAsTracking().Any(x => x.DID == id);

            return dept;
        }
    }
}

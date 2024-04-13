using SchoolProject.Domain.Entities.Procedures;

namespace SchoolProject.Infrustructure.Interface.Procedures
{
    public interface IDepartmentStudentCountProcRepository
    {
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParams para);
    }
}

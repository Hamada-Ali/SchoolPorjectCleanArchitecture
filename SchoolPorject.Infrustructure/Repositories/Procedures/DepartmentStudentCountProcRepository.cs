using SchoolProject.Domain.Entities.Procedures;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.Interface.Procedures;
using StoredProcedureEFCore;

namespace SchoolProject.Infrustructure.Repositories.Procedures
{
    public class DepartmentStudentCountProcRepository : IDepartmentStudentCountProcRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentStudentCountProcRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParams para)
        {
            // working with procedure example (You can copy and past ) => remember to use useproc package check dependancies 
            var rows = new List<DepartmentStudentCountProc>();
            await _dbContext.LoadStoredProc(nameof(DepartmentStudentCountProc))
                .AddParam(nameof(DepartmentStudentCountProcParams.DID), para.DID)
                .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());

            return rows;
        }
    }
}

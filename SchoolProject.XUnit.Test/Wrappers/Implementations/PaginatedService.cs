using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;
using SchoolProject.XUnit.Test.Wrappers.Interfaces;

namespace SchoolProject.XUnit.Test.Wrappers.Implementations
{
    public class PaginatedService : IPaginatedService<Student>
    {
        public Task<PaginatedResult<Student>> ReturnPaginatedResult(IQueryable<Student> source, int pageNumber, int pageSize)
        {
            return source.ToPaginatedListAsync(pageNumber, pageSize);
        }
    }
}

using MediatR;
using SchoolProject.Core.Features.Students.Queries.Dto;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<StudentPaginatedList>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderyingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}

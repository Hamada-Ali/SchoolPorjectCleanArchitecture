using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Dto;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
    public class GetDepartmentStudentCountQuery : IRequest<ResponseInformation<List<GetDepartmentStudentCountDto>>>
    {
    }
}

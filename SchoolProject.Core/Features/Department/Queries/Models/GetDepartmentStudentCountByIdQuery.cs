using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Dto;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
    public class GetDepartmentStudentCountByIdQuery : IRequest<ResponseInformation<GetDepartmentStudentCountByIdDto>>
    {
        public int DID { get; set; }
    }
}

using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Dto;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
    public class GetByIdDepartmentQuery : IRequest<ResponseInformation<GetByIdDepartmentResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNubmer { get; set; }
        public int StudnetPageSize { get; set; }

    }
}

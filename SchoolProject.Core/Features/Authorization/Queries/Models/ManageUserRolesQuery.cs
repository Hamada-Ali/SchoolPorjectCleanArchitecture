using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Dto;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserRolesQuery : IRequest<ResponseInformation<ManageUserRolesDto>>
    {
        public int UserId { get; set; }

        public ManageUserRolesQuery(int id)
        {
            UserId = id;
        }
    }

}

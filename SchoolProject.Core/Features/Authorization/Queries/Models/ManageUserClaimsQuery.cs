using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Dto;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery : IRequest<ResponseInformation<ManageUserClaimsResults>>
    {
        public int UserId { get; set; }

        public ManageUserClaimsQuery(int id)
        {
            UserId = id;
        }
    }
}

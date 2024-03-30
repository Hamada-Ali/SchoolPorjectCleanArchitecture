using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<ResponseInformation<string>>
    {
        public string RoleName { get; set; }

    }
}

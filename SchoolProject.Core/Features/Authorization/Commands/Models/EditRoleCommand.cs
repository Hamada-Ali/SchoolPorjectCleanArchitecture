using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Domain.Dto;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleDto, IRequest<ResponseInformation<string>>
    {
    }
}

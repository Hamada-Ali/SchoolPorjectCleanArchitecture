using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Command.Model
{
    public class ResetPasswordCommand : IRequest<ResponseInformation<string>>
    {
        public string Email { get; set; }

    }
}

using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Command.Model
{
    // final step of reseting password
    public class ResetPasswordWithConfirmCommand : IRequest<ResponseInformation<string>>
    {
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
        public string Email { get; set; }
    }
}

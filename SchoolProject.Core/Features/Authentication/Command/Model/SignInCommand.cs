using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Command.Model
{
    public class SignInCommand : IRequest<ResponseInformation<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

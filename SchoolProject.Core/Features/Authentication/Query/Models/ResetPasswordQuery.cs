using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Query.Models
{
    public class ResetPasswordQuery : IRequest<ResponseInformation<string>>
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}

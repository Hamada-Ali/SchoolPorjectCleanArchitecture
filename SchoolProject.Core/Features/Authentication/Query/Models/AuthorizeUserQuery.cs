using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Query.Models
{
    public class AuthorizeUserQuery : IRequest<ResponseInformation<string>>
    {
        public string AccessToken { get; set; }

    }
}

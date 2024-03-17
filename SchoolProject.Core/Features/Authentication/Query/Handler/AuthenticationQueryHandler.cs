using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Query.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authentication.Query.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                                IRequestHandler<AuthorizeUserQuery, ResponseInformation<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                            IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authenticationService = authenticationService;
        }

        public async Task<ResponseInformation<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);

            if (result == "NotExpired")
            {
                return Success(result);
            }

            return Unauthorized<string>(_stringLocalizer[SharedResourcesKeys.TokenIsExpired]);
        }
    }
}


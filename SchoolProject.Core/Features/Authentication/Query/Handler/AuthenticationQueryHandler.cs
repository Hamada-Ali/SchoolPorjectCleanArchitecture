using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Query.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authentication.Query.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                                IRequestHandler<AuthorizeUserQuery, ResponseInformation<string>>,
                                                IRequestHandler<ConfirmEmailQuery, ResponseInformation<string>>,
                                                IRequestHandler<ResetPasswordQuery, ResponseInformation<string>>

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

        public async Task<ResponseInformation<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmail(request.UserId, request.Code);

            switch (confirmEmail)
            {
                case "ErrorWhenConfirmEmail": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.ErrorWhenConfirmEmail]);
                default: return Success<string>("Email Confirmation Successed");
            }
        }

        public async Task<ResponseInformation<string>> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ResetPassword(request.Code, request.Email);

            switch (result)
            {
                case "UserNotFound": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNotExist]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InvalidCode]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(result);
            }
        }
    }
}


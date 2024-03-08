using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Command.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authentication.Command.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                                IRequestHandler<SignInCommand, ResponseInformation<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                            UserManager<User> userManager,
                                            SignInManager<User> signInManager,
                                            IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }

        public async Task<ResponseInformation<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            // check if the user is exist
            var user = await _userManager.FindByNameAsync(request.UserName);
            // not found
            if (user == null)
            {
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserNotExist]);
            }
            // try To login
            var signIn = _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            // password is wrong
            if (!signIn.IsCompletedSuccessfully)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);
            }
            // generate token
            var token = await _authenticationService.GetJwtToken(user);
            // return token
            return Success(token);
        }
    }
}

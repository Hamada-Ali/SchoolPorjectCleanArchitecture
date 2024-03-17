using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Command.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authentication.Command.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                                IRequestHandler<SignInCommand, ResponseInformation<JwtAuthDto>>,
                                                IRequestHandler<RefreshTokenCommand, ResponseInformation<JwtAuthDto>>
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

        public async Task<ResponseInformation<JwtAuthDto>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            // check if the user is exist
            var user = await _userManager.FindByNameAsync(request.UserName);
            // not found
            if (user == null)
            {
                return NotFound<JwtAuthDto>(_stringLocalizer[SharedResourcesKeys.UserNotExist]);
            }
            // try To login
            var signIn = _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            // password is wrong
            if (!signIn.IsCompletedSuccessfully)
            {
                return BadRequest<JwtAuthDto>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);
            }

            if (!signIn.Result.Succeeded)
            {
                return BadRequest<JwtAuthDto>($"{signIn.Exception.Message}");
            }
            // generate token
            var token = await _authenticationService.GetJwtToken(user);
            // return token
            return Success(token);
        }

        public async Task<ResponseInformation<JwtAuthDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {

            var jwtToken = _authenticationService.ReadJwtToken(request.AccessToken);
            var userIdAndExpireDate = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthDto>(_stringLocalizer[SharedResourcesKeys.AlgorithmIsWrong]);
                case ("TokenIsNotExpired", null): return Unauthorized<JwtAuthDto>(_stringLocalizer[SharedResourcesKeys.TokenIsNotExpired]);
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthDto>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthDto>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);

            }

            var (userId, expiryDate) = userIdAndExpireDate;

            // generate token
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthDto>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var result = await _authenticationService.GetRefreshToken(user, jwtToken, expiryDate, request.RefreshToken);
            return Success(result);
        }
    }
}



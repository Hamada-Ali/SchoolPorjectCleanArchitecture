using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                        IRequestHandler<AddUserCommand, ResponseInformation<string>>,
                                        IRequestHandler<UpdateUserCommand, ResponseInformation<string>>,
                                        IRequestHandler<DeleteUserCommand, ResponseInformation<string>>,
                                        IRequestHandler<ChangeUserPasswordCommand, ResponseInformation<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _user;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailsService _emailsService;
        private readonly IApplicationUserService _applicationUserService;

        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper,
                                    UserManager<User> user, IHttpContextAccessor httpContextAccessor, IEmailsService emailsService,
                                    IApplicationUserService applicationUserService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _user = user;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _applicationUserService = applicationUserService;
        }
        public async Task<ResponseInformation<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //// mapping
            var mappedUser = _mapper.Map<User>(request);

            // create user
            var createUser = await _applicationUserService.AddUserAsync(mappedUser, request.Password);


            switch (createUser)
            {
                case "EmailIsExist": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
                case "UserNameIsExist": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
                case "ErrorInCreateUser": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedCreateOperation]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.OperationFailed]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(createUser);
            }
        }


        public async Task<ResponseInformation<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _user.FindByIdAsync(request.Id.ToString());

            // check if the user is exist by email
            if (user == null)
            {
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var mappedUser = _mapper.Map(request, user);

            var result = await _user.UpdateAsync(mappedUser);

            if (!result.Succeeded)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedCreateOperation]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.updated]);
        }

        public async Task<ResponseInformation<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _user.FindByIdAsync(request.Id.ToString());

            if (user == null)
            {
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var result = _user.DeleteAsync(user);

            if (!result.Result.Succeeded)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.OperationFailed]);
            }

            return Success<string>(_stringLocalizer[SharedResourcesKeys.success]);
        }

        public async Task<ResponseInformation<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            // get user by id
            var user = await _user.FindByIdAsync(request.Id.ToString());

            if (user == null)
            {
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var result = await _user.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.OperationFailed]);
            }

            return Success<string>(_stringLocalizer[SharedResourcesKeys.success]);
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Features.IdentityUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                        IRequestHandler<AddUserCommand, ResponseInformation<string>>,
                                        IRequestHandler<UpdateUserCommand, ResponseInformation<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _user;

        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper,
                                    UserManager<User> user) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _user = user;
        }
        public async Task<ResponseInformation<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // if email exist
            var user = await _user.FindByEmailAsync(request.Email);

            // the Email already exists
            if (user != null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
            }

            // if username is exist
            var userByUserName = await _user.FindByNameAsync(request.UserName);


            // the user already exists
            if (userByUserName != null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
            }

            // mapping
            var mappedUser = _mapper.Map<User>(request);

            // create user
            var createUser = await _user.CreateAsync(mappedUser, request.Password);

            // failed
            if (!createUser.Succeeded)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedCreateOperation] + $" => Description: {createUser.Errors.FirstOrDefault().Description}");
            }

            // success
            return Created("");
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
    }
}

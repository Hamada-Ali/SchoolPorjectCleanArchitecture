using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.IdentityUser.Queries.Dto;
using SchoolProject.Core.Features.IdentityUser.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Features.IdentityUser.Queries.Handlers
{
    public class GetUserByIdHandler : ResponseHandler,
                    IRequestHandler<GetUserByIdQuery, ResponseInformation<GetUserByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly UserManager<User> _userManager;

        public GetUserByIdHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, UserManager<User> userManager) : base(localizer)
        {
            _localizer = localizer;
            _mapper = mapper;
            _userManager = userManager;
        }



        public async Task<ResponseInformation<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == request.Id);

            //failed
            if (user == null)
            {
                return NotFound<GetUserByIdResponse>(_localizer[SharedResourcesKeys.NotFound]);
            }

            var mappedUser = _mapper.Map<GetUserByIdResponse>(user); // you can't user multithreading with get single record

            return Success(mappedUser);
        }
    }
}

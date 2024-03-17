using SchoolProject.Core.Features.IdentityUser.Queries.Dto;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Mapping.IdentityUser
{
    public partial class IdentityUserProfile
    {
        public void GetUserPaginatedListMapper()
        {
            CreateMap<User, GetUserListResponse>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));

            // note you can leave it like that and it will work because members names are the same
            //   CreateMap<User, GetUserListResponse>();

        }
    }
}

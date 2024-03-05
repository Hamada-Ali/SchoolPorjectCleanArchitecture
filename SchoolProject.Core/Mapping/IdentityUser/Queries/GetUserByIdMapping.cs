using SchoolProject.Core.Features.IdentityUser.Queries.Dto;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Mapping.IdentityUser
{
    public partial class IdentityUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}

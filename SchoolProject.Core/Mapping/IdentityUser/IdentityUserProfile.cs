using AutoMapper;

namespace SchoolProject.Core.Mapping.IdentityUser
{
    public partial class IdentityUserProfile : Profile
    {
        public IdentityUserProfile()
        {
            AddUserMapping();
            GetUserPaginatedListMapper();
            GetUserByIdMapping();
        }
    }
}

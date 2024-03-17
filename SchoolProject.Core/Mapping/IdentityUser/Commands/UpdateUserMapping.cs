using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Mapping.IdentityUser
{
    public partial class IdentityUserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, User>();
        }
    }
}

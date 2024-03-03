using SchoolProject.Core.Features.IdentityUser.Commands.Models;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Mapping.IdentityUser
{
    public partial class IdentityUserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>()
                            .ForMember(dto => dto.FullName, options => options.MapFrom(entity => entity.FullName))
                            .ForMember(dto => dto.UserName, options => options.MapFrom(entity => entity.UserName))
                            .ForMember(dto => dto.Email, options => options.MapFrom(entity => entity.Email))
                            .ForMember(dto => dto.Address, options => options.MapFrom(entity => entity.Address))
                            .ForMember(dto => dto.Country, options => options.MapFrom(entity => entity.Country))
                            .ForMember(dto => dto.PhoneNumber, options => options.MapFrom(entity => entity.PhoneNubmer));

            // **** NOTE **** //
            // YOU CAN JUST ONLY USE 
            //CreateMap<AddUserCommand, User>();
            // without any additional mapping because Entities Names are the same
        }
    }
}

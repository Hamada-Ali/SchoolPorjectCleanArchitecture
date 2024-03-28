using SchoolProject.Core.Features.Authorization.Queries.Dto;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRolesListMapping()
        {
            CreateMap<Role, GetRolesListDto>();
            //.ForMember(dto => dto.Id, options => options.MapFrom(src => src.Id))
            //.ForMember(dto => dto.Name, options => options.MapFrom(src => src.Name));
        }
    }
}

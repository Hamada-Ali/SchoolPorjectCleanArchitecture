using SchoolProject.Domain.Dto;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Services.Interface
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExist(string roleName);
        public Task<string> EditRoleAsync(EditRoleDto Dto);
        public Task<string> DeleteRoleAsync(int Id);
        public Task<bool> IsRoleExistById(int Id);
        public Task<List<Role>> GetRolesList();
        public Task<Role> GetRoleById(int Id);
        public Task<ManageUserRolesDto> GetManageUserRolesData(User user);
        public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);
        public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);
        public Task<ManageUserClaimsResults> ManageUserClaimsData(User user);
    }
}

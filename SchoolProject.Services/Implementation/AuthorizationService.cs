
using Microsoft.AspNetCore.Identity;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager;

        public AuthorizationService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<string> AddRoleAsync(string roleName)
        {
            var identityRole = new Role();
            identityRole.Name = roleName;
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Infrustructure.Seeding
{
    public static class RoleSeeding
    {
        public static async Task SeedAsync(RoleManager<Role> _roleManager)
        {
            var rolesCount = await _roleManager.Roles.CountAsync();

            if (rolesCount <= 0)
            {
                await _roleManager.CreateAsync(new Role() { Name = "admin" });

                await _roleManager.CreateAsync(new Role() { Name = "user" });
            }
        }
    }
}

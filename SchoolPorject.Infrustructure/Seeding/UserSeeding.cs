using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Infrustructure.Seeding
{
    public static class UserSeeding
    {
        public static async Task SeedAsync(UserManager<User> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();

            if (usersCount <= 0)
            {
                var Admin = new User()
                {
                    UserName = "Admin",
                    Email = "admin@project.com",
                    FullName = "Admin",
                    Country = "Egypt",
                    PhoneNumber = "1234567890",
                    Address = "Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await _userManager.CreateAsync(Admin, "admin");

                await _userManager.AddToRoleAsync(Admin, "admin");
                await _userManager.AddToRoleAsync(Admin, "user");
            }
        }
    }
}

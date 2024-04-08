using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Services.AuthServices.Interface;
using System.Security.Claims;

namespace SchoolProject.Services.AuthServices.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<User> GetUser()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            return user;
        }

        public int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }

            return int.Parse(userId);
        }

        public async Task<List<string>> GetUserRolesAsync()
        {
            var user = await GetUser();

            var roles = await _userManager.GetRolesAsync(user);


            return roles.ToList();
        }
    }
}

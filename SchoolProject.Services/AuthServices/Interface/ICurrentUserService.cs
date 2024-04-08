using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Services.AuthServices.Interface
{
    public interface ICurrentUserService
    {
        public Task<User> GetUser();
        public int GetUserId();

        public Task<List<string>> GetUserRolesAsync();
    }
}

using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Services.Interface
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}

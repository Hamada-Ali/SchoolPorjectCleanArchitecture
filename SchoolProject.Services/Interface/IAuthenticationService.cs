using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Services.Interface
{
    public interface IAuthenticationService
    {
        public Task<string> GetJwtToken(User user);
    }
}

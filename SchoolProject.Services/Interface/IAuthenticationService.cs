using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Services.Interface
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthDto> GetJwtToken(User user);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string RefreshToken);
        public Task<JwtAuthDto> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? ExpiryDate, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
    }
}

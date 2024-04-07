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
        public Task<string> ConfirmEmail(int? userId, string? code);
        public Task<string> SendResetPasswordCode(string Email);
        public Task<string> ResetPassword(string Code, string Email);
        public Task<string> ResetPasswordConfirm(string password, string Email);

    }
}

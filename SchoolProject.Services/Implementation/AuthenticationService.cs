
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtConfig _jwtConfig;

        public AuthenticationService(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }
        public Task<string> GetJwtToken(User user)
        {
            // issuer : who this token belong to 
            // audience : 
            // claims  = Payload ( the data used to geenrate payload) 
            // notBefore : how long the time it takes to enable this token
            // expire : expiration date of the token
            // signInCredentials : the alogrithm that used in token and secret key 
            // Note : Jwt Data Should be in Appsetting file
            var claims = new List<Claim>()
            {
                new Claim("UserName", user.UserName),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim("Email", user.Email)

            };
            var token = new JwtSecurityToken(
                        _jwtConfig.Issuer, //"SchoolProject",
                        _jwtConfig.Audience, //"",
                        claims,
                        null,
                        DateTime.UtcNow.AddDays(30),
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)), SecurityAlgorithms.HmacSha256Signature)
                        );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token); // create token 
            // return token | Note : we use Task.FromResult because the function isn't Multithread if you don't want to use it add async to method
            return Task.FromResult(accessToken);
        }
    }
}

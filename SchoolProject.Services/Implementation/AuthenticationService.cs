
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Services.Interface;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {

        #region Fields
        private readonly JwtConfig _jwtConfig;
        private readonly UserManager<User> _userManager;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ConcurrentDictionary<string, RefrechToken> _userRefreshToken;
        private readonly IEmailsService _emailsService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IEncryptionProvider _encryptionProvider;
        #endregion

        #region constructor
        public AuthenticationService(JwtConfig jwtConfig, IRefreshTokenRepository refreshTokenRepository,
            UserManager<User> userManager, IEmailsService emailsService, ApplicationDbContext applicationDbContext)
        {
            _jwtConfig = jwtConfig;
            _userManager = userManager;
            _refreshTokenRepository = refreshTokenRepository;
            _userRefreshToken = new ConcurrentDictionary<string, RefrechToken>();
            _emailsService = emailsService;
            _applicationDbContext = applicationDbContext;
            // this is the key we can decrypt the column with
            _encryptionProvider = new GenerateEncryptionProvider("68d09eda6a294cf7aeb945e56f5c0b8568d09eda6a294cf7aeb945e56f5c0b85");
        }

        #endregion

        #region GetJwtTokenMethod
        public async Task<JwtAuthDto> GetJwtToken(User user)
        {
            var (jwt, accessToken) = await GenerateJwtToken(user);
            var refreshToken = GetRefrechToken(user.UserName);

            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtConfig.AccessTokenExpireDate),
                IsUsed = true,
                IsRevoked = false,
                JwtId = jwt.Id,
                RefreshToken = refreshToken.tokenString,
                Token = accessToken,
                UserId = user.Id
            };

            await _refreshTokenRepository.AddAsync(userRefreshToken);



            // we add it to create the structure after this we can delete it
            //var RefreshTokenResult = await _refreshTokenRepository.AddAsync(userRefreshToken);

            var response = new JwtAuthDto();

            response.refrechToken = refreshToken;
            response.AccessToken = accessToken;

            // return token | Note : we use Task.FromResult because the function isn't Multithread if you don't want to use it add async to method
            return response;
        }
        #endregion

        #region GenerateJwtTokenMethod
        private async Task<(JwtSecurityToken, string)> GenerateJwtToken(User user)
        {

            // issuer : who this token belong to 
            // audience : 
            // claims  = Payload ( the data used to geenrate payload) 
            // notBefore : how long the time it takes to enable this token
            // expire : expiration date of the token
            // signInCredentials : the alogrithm that used in token and secret key 
            // Note : Jwt Data Should be in Appsetting file

            var roles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Email, user.Email),

            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            claims.AddRange(userClaims);

            var token = new JwtSecurityToken(
                        _jwtConfig.Issuer, //"SchoolProject",
                        _jwtConfig.Audience, //"",
                        claims,
                        null,
                        DateTime.UtcNow.AddDays(_jwtConfig.AccessTokenExpireDate),
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)), SecurityAlgorithms.HmacSha256Signature)
                        );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token); // create token 

            return (token, accessToken);

        }
        #endregion

        #region GetRefrechTokenMethod
        // refresh token 
        private RefrechToken GetRefrechToken(string username)
        {
            var refreshToken = new RefrechToken
            {
                ExpirationDate = DateTime.Now.AddDays(_jwtConfig.RefreshTokenExpireDate),
                Username = username,
                tokenString = GenerateRefreshToken()
            };

            _userRefreshToken.AddOrUpdate(refreshToken.tokenString, refreshToken, (s, t) => refreshToken);
            return refreshToken;
        }
        #endregion

        #region GenerateRefreshToken
        // in every refresh token we use this function (this function create for us a refresh toke   n)
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            var randomNumberGenerate = RandomNumberGenerator.Create();

            randomNumberGenerate.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
        #endregion


        #region GetRefreshTokenMethod
        public async Task<JwtAuthDto> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? ExpiryDate, string refreshToken)
        {

            var (jwtSecurityToken, newToken) = await GenerateJwtToken(user);

            var response = new JwtAuthDto();
            response.AccessToken = newToken;
            var refreshTokenResult = new RefrechToken();
            refreshTokenResult.Username = jwtToken.Claims.FirstOrDefault(x => x.Type == "Username").Value;
            refreshTokenResult.tokenString = refreshToken;
            refreshTokenResult.ExpirationDate = (DateTime)ExpiryDate;
            response.refrechToken = refreshTokenResult;

            return response;

        }

        public JwtSecurityToken ReadJwtToken(string AccessToken)
        {
            if (string.IsNullOrEmpty(AccessToken))
            {
                throw new ArgumentException(nameof(AccessToken));
            }

            var handler = new JwtSecurityTokenHandler();

            var response = handler.ReadJwtToken(AccessToken);

            return response;
        }

        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();

            //  var response = handler.ReadJwtToken(accessToken);
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtConfig.ValidateIssuer,
                ValidIssuers = new[] { _jwtConfig.Issuer },
                ValidateIssuerSigningKey = _jwtConfig.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)),
                ValidAudience = _jwtConfig.Audience,
                ValidateAudience = _jwtConfig.ValidateAudience,
                ValidateLifetime = _jwtConfig.ValidateLifeTime,
            };

            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "Invalid Token";
                }

                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("token Algorithms is not equal", null);
            }

            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("token is not expired", null);
            }

            // get user
            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "Id").Value; // to get the value not the kye itself
            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(x => x.Token == accessToken && x.RefreshToken == refreshToken && x.UserId == int.Parse(userId));


            if (userRefreshToken == null)
            {
                return ("this refresh token is not found", null);
            }

            // expired or not
            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("Refresh token is  expired", null);
            }

            var expiryDate = userRefreshToken.ExpiryDate;
            return (userId, expiryDate);
        }

        public async Task<string> ConfirmEmail(int? userId, string code)
        {
            if (userId == null || code == null)
                return "ErrorWhenConfirmEmail";

            var user = await _userManager.FindByIdAsync(userId.ToString());

            var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);

            if (!confirmEmail.Succeeded)
            {
                return "ErrorWhenConfirmEmail";
            }

            return "Success";
        }

        public async Task<string> SendResetPasswordCode(string Email)
        {
            var trans = _applicationDbContext.Database.BeginTransaction();
            try
            {

                // get user
                var user = await _userManager.FindByEmailAsync(Email);

                if (user == null) { return "UserNotFound"; }

                Random generator = new Random();
                string randomNumber = generator.Next(0, 1000000).ToString("D6");

                user.Code = randomNumber;
                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                {
                    return "ErrorInUpdateUser";
                }

                var message = "Code To Reset Password: " + user.Code;

                var result = await _emailsService.SendEmail(user.Email, message, "Reset Password");

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }



        }

        public async Task<string> ResetPassword(string Code, string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null) { return "UserNotFound"; }

            var userCode = user.Code;

            if (userCode == Code) { return "Success"; }

            return "Failed";
        }

        public async Task<string> ResetPasswordConfirm(string password, string Email)
        {
            var trans = await _applicationDbContext.Database.BeginTransactionAsync();

            try
            {

                var user = await _userManager.FindByEmailAsync(Email);

                if (user == null) { return "UserNotFound"; }

                await _userManager.RemovePasswordAsync(user);

                await _userManager.AddPasswordAsync(user, password);

                await trans.CommitAsync();

                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();

                return "Failed";
            }

        }
        #endregion
    }
}


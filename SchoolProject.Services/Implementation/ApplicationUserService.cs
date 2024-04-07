using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Services.Interface;

namespace SchoolProject.Services.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<User> _user;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailsService _emailsService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IUrlHelper _urlHelper;

        public ApplicationUserService(UserManager<User> user, IHttpContextAccessor httpContextAccessor,
            IEmailsService emailsService, ApplicationDbContext applicationDbContext, IUrlHelper urlHelper)
        {
            _user = user;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _applicationDbContext = applicationDbContext;
            _urlHelper = urlHelper;
        }

        public async Task<string> AddUserAsync(User newUser, string password)
        {
            // transaction rollback
            var trans = await _applicationDbContext.Database.BeginTransactionAsync();

            try
            {
                // if email exist
                var user = await _user.FindByEmailAsync(newUser.Email);

                // the Email already exists
                if (user != null)
                {
                    return "EmailIsExist";
                }

                // if username is exist
                var userByUserName = await _user.FindByNameAsync(newUser.UserName);


                // the user already exists
                if (userByUserName != null)
                {
                    return "UserNameIsExist";
                }

                // create user
                var createUser = await _user.CreateAsync(newUser, password);

                // failed
                if (!createUser.Succeeded)
                {
                    return string.Join(",", createUser.Errors.Select(x => x.Description).ToList());
                }

                await _user.AddToRoleAsync(newUser, "user");

                // send confirm email
                var code = await _user.GenerateEmailConfirmationTokenAsync(newUser);

                var requestAccessor = _httpContextAccessor.HttpContext.Request;

                var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userid = newUser.Id, code = code });

                var message = $"To Confirm Your Email Click On The Following Link: <a href='{returnUrl}'>Click me</a>";

                //$"/Api/V1/Authentication/ConfirmEmail?userId={newUser.Id}&code={code}";

                // message or body
                await _emailsService.SendEmail(newUser.Email, message, "Confirm Email");



                await trans.CommitAsync();

                return "Success";

            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
    }
}

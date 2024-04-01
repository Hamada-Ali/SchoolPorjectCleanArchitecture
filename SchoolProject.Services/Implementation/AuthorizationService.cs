
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Dto;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Infrustructure.Domain;
using SchoolProject.Services.Interface;
using System.Security.Claims;

namespace SchoolProject.Services.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<string> AddRoleAsync(string roleName)
        {
            var identityRole = new Role();
            identityRole.Name = roleName;
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteRoleAsync(int Id)
        {

            // check role exist or not
            var role = await _roleManager.FindByIdAsync(Id.ToString());

            if (role == null)
            {
                return "NotFound";
            }


            // user have this role or not
            var users = await _userManager.GetUsersInRoleAsync(role.Name);

            if (users != null || users.Count() > 0) { return "Used"; }

            var deleteRole = _roleManager.DeleteAsync(role);

            if (!deleteRole.IsCompletedSuccessfully)
            {
                return "Failed to Delete";
            }

            return "Success";
        }

        public async Task<string> EditRoleAsync(EditRoleDto Dto)
        {
            try
            {
                // Check if the role exists
                var role = await _roleManager.FindByIdAsync(Dto.Id.ToString());
                if (role == null)
                {
                    return "Role not found.";
                }

                // Update role name
                role.Name = Dto.Name;

                // Attempt to update the role
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return "Success";
                }
                else
                {
                    // If update failed, construct error message
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return "Failed to update role: " + errors;
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                return "An error occurred: " + ex.Message;
            }
        }

        public async Task<List<Role>> GetRolesList()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int Id)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> IsRoleExistById(int Id)
        {
            var role = await _roleManager.FindByIdAsync(Id.ToString());

            if (role == null)
            {
                return false;
            }

            return true;
        }

        public async Task<ManageUserRolesDto> GetManageUserRolesData(User user)
        {
            var response = new ManageUserRolesDto();
            var userRolesList = new List<UserRoles>();

            // user roles
            var userRoles = await _userManager.GetRolesAsync(user);

            // all roles
            var roles = await _roleManager.Roles.ToListAsync();

            response.UserId = user.Id;
            foreach (var role in roles)
            {
                var userrole = new UserRoles();
                userrole.Id = role.Id;
                userrole.Name = role.Name;

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userrole.HasRole = true;
                }
                else
                {
                    userrole.HasRole = false;
                }

                userRolesList.Add(userrole);
            }

            response.userRoles = userRolesList;

            return response;

        }

        public async Task<string> UpdateUserRoles(UpdateUserRolesRequest request)
        {

            var transact = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());

                if (user == null)
                {
                    return "NotFound";
                }

                var userRoles = await _userManager.GetRolesAsync(user);

                var removeRoles = await _userManager.RemoveFromRolesAsync(user, userRoles);

                if (!removeRoles.Succeeded)
                {
                    return "FailedToRemoveOldRoles";
                }

                var selectedRoles = request.userRoles.Where(x => x.HasRole == true).Select(x => x.Name);

                var addRolesResult = await _userManager.AddToRolesAsync(user, selectedRoles);

                if (!addRolesResult.Succeeded)
                {
                    return "FailedToAddNewRoles";
                }

                await transact.CommitAsync();

                return "Success";
            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToAddUserRoles";
            }
        }

        public async Task<ManageUserClaimsResults> ManageUserClaimsData(User user)
        {

            var response = new ManageUserClaimsResults();
            var userClaimsList = new List<UserClaims>();
            response.UserId = user.Id;
            // get user claims
            var userClaims = await _userManager.GetClaimsAsync(user);

            foreach (var claim in ClaimsStore.claims)
            {
                var claimsTemp = new UserClaims();

                claimsTemp.Type = claim.Type;

                if (userClaims.Any(x => x.Type == claim.Type))
                {
                    claimsTemp.Value = true;
                }
                else
                {
                    claimsTemp.Value = false;
                }
                userClaimsList.Add(claimsTemp);
            }
            response.userClaims = userClaimsList;

            return response;
        }

        public async Task<string> UpdateUserClaims(UpdateUserClaimsRequest request)
        {
            var transact = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());

                if (user == null)
                {
                    return "NotFound";
                }
                var userClaims = await _userManager.GetClaimsAsync(user);

                var removeClaimsResult = await _userManager.RemoveClaimsAsync(user, userClaims);

                if (!removeClaimsResult.Succeeded)
                {
                    return "FailedToRemoveOldClaims";
                }

                var claims = request.userClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));

                var addUserClaimResult = await _userManager.AddClaimsAsync(user, claims);

                if (!addUserClaimResult.Succeeded)
                {
                    return "FailedToAddNewClaims";
                }

                await transact.CommitAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToUpdateClaims";
            }
        }
    }
}

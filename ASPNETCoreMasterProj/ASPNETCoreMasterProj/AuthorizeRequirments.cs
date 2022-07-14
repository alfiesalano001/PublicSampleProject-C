using Repositories.BindingModels;
using Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Repositories
{
    public class AuthorizeRequirments : IAuthorizationRequirement
    {
    }

    public class CanAuthorizeHandle : AuthorizationHandler<AuthorizeRequirments>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CanAuthorizeHandle(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizeRequirments requirement)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if (appUser == null)
            {
                return;
            }

            //if (resource.CreatedBy == appUser.UserName)
            //{
            //    context.Succeed(requirement);
            //}
        }
    }
}
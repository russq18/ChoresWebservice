
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace ChoresAPI.Authorization
{
    public class OnlyParentsAuthorizationHandler : AuthorizationHandler<OnlyParentsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyParentsRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Parent))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

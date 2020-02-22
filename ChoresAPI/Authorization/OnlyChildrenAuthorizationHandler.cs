using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace ChoresAPI.Authorization
{
    public class OnlyChildrenAuthorizationHandler : AuthorizationHandler<OnlyChildrenRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyChildrenRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Child))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

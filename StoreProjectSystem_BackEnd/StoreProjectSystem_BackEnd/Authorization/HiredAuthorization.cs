using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace StoreProjectSystem_BackEnd.Authorization
{
    public class HiredAuthorization : AuthorizationHandler<Employee>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Employee requirement)
        {
            var Hired = context.User.FindFirst(claim => claim.Type == "Hired");

            if (Hired == null) return Task.CompletedTask;

            if (bool.TryParse(Hired.Value, out bool isHired))
            {
                if (isHired == requirement.Hired) 
                {                 
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace StoreProjectSystem_BackEnd.Authorization
{
    public class HiredAuthorization : AuthorizationHandler<Employee>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Employee requirement)
        {
            return Task.CompletedTask;
        }
    }
}

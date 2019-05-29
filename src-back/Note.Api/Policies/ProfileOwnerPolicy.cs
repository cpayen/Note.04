using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Note.Api.Policies
{
    public class ProfileOwnerRequirement : IAuthorizationRequirement {}

    public class ProfileOwnerHandler : AuthorizationHandler<ProfileOwnerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProfileOwnerRequirement requirement)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (requirement == null)
            {
                throw new ArgumentNullException(nameof(requirement));
            }

            var authFilterCtx = (AuthorizationFilterContext)context.Resource;
            var httpContext = authFilterCtx.HttpContext;

            var claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
            var tokenUserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var routeUserId = httpContext.GetRouteValue("id")?.ToString();

            if (tokenUserId.Value == routeUserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

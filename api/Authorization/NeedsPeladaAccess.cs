using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace api.Authorization
{
    public class NeedsPeladaAccess : AuthorizationHandler<NeedsPeladaAccessRequirement>
    {
        readonly IHttpContextAccessor contextAccessor;

        public NeedsPeladaAccess(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NeedsPeladaAccessRequirement requirement)
        {
            var httpContext = contextAccessor.HttpContext;
            var path = httpContext.Request.Path;

            //var pathPart = path.Split('/');

            if (!context.User.HasClaim(c => c.Type.Equals("id")))
            {
                return Task.CompletedTask;
            }


            var userId = context.User.Claims.First(w => w.Type.Equals("id"));

            return Task.CompletedTask;

            throw new NotImplementedException();
        }
    }
}

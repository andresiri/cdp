using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using domain.Services;

namespace api.Authorization
{
    public class NeedsPeladaAccess : AuthorizationHandler<NeedsPeladaAccessRequirement>
    {
        readonly IHttpContextAccessor _contextAccessor;
        readonly IPeladaUserService _peladaUserService;

        public NeedsPeladaAccess(IHttpContextAccessor contextAccessor, IPeladaUserService peladaUserService)
        {
            _contextAccessor = contextAccessor;
            _peladaUserService = peladaUserService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NeedsPeladaAccessRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type.Equals("userId")))
            {
                return Task.CompletedTask;
            }

            var httpContext = _contextAccessor.HttpContext;
            var pathSplit = httpContext.Request.Path.Value.Split('/');

            var indexOfPelada = Array.IndexOf(pathSplit, "pelada");

            if (indexOfPelada > -1) {

                var userId = Convert.ToInt32(context.User.Claims.First(c => c.Type.Equals("userId")).Value);
                var peladaId = Convert.ToInt32(pathSplit[indexOfPelada + 1]);

                var peladasUser = _peladaUserService.GetPeladasByUser(userId);

                var hasAccessToPelada = peladasUser.Any(w => w.PeladaId.Equals(peladaId));

                if (!hasAccessToPelada)
                {
                    return Task.CompletedTask;
                }

                context.Succeed(requirement);
            }
            else {

                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

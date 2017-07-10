using System;
using System.Linq;
using System.Threading.Tasks;
using api.Context.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace api.Authorization
{
    public class NeedsPeladaAccess : AuthorizationHandler<NeedsPeladaAccessRequirement>
    {
        readonly IHttpContextAccessor _contextAccessor;
        readonly IUnitOfWork _unitOfWork;

        public NeedsPeladaAccess(IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork)
        {
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
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

                var peladasUser = _unitOfWork.PeladaUserRepository.GetPeladasByUser(userId);

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

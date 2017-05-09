using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CartolaDaPelada.Controllers
{
    [Authorize(Policy = "NeedsPeladaAccess")]
    public class BaseController : Controller
    {
        public int GetUserId()
        {
            var userId = Convert.ToInt32(User.Claims.Where(w => w.Type.Equals("userId")).First().Value);
            return userId;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CartolaDaPelada.Controllers
{    
    [Authorize]
    public class BaseController : Controller
    {
        public int GetUserId()
        {
            var userId = Convert.ToInt32(User.Claims.First(w => w.Type.Equals("userId")).Value);
            return userId;
        }
    }
}
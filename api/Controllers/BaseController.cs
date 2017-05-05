using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CartolaDaPelada.Controllers
{
    public class BaseController : Controller
    {
        public int GetUserId()
        {
            var userId = Convert.ToInt32(User.Claims.Where(w => w.Type.Equals("id")).First().Value);
            return userId;
        }
    }
}
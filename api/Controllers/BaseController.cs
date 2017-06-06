using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using domain.Entities.Exceptions;

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

        public JsonResult FormatException(Exception e) {

            var jsonException = new JsonException();

            jsonException.Stacktrace = e.StackTrace;
            jsonException.Message = e.Message;

            var type = e.GetType();

            if (type == typeof(CustomException)){

                jsonException.Info = ((CustomException)e).Info;
                jsonException.Type = ((CustomException)e).Type;
            }

            return Json(jsonException);
        }
    }
}
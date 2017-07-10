using System;
using System.Linq;
using domain.Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            var jsonException = new JsonException()
            {
                Stacktrace = e.StackTrace,
                Message = e.Message
            };
            var type = e.GetType();

            if (type == typeof(CustomException)){

                var customException = (CustomException)e;

                jsonException.Info = customException.Info;
                jsonException.Type = customException.Type;

                if (!string.IsNullOrEmpty(customException.ErrorMsg)) {

                    jsonException.Message = customException.ErrorMsg;
                }
            }

            return Json(jsonException);
        }
    }
}
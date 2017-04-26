using System;
using domain.Entities;
using domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public JsonResult Create([FromBody]User obj)
        {
            try
            {
                var newUser = _userService.Create(obj);
                return Json(newUser);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete([FromRoute]int id)
        {
            try
            {
                _userService.Delete(id);

                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }
    }
}
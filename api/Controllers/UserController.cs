using System;
using CartolaDaPelada.Controllers;
using domain.Entities;
using domain.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using api.ViewModel;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public JsonResult Create([FromBody]User obj)
        {
            try
            {
                var newUser = _userService.Create(obj);

                var userViewModel = _mapper.Map<UserViewModel>(newUser);

                return Json(userViewModel);
            }
            catch (Exception ex)
            {
                return Json(ex);
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
                return Json(ex);
            }
        }
    }
}
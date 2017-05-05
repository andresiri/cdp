using System;
using api.Authorization;
using CartolaDaPelada.Controllers;
using domain.Entities;
using domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class PeladaController : BaseController
    {
        readonly IPeladaService _peladaService;
        readonly IPeladaUserService _peladaUserService;

        public PeladaController(IPeladaService peladaService, IPeladaUserService peladaUserService)
        {
            _peladaService = peladaService;
            _peladaUserService = peladaUserService;
        }

        [HttpPost]
        public JsonResult Create([FromBody]Pelada obj)
        {
            try
            {
                var newPelada = _peladaService.Create(obj);
                return Json(newPelada);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        //[Authorize(Policy = "NeedsPeladaAccess")]
        [Route("{peladaId}/add-user")]
        public JsonResult AddUserToPelada([FromRoute]int peladaId, [FromBody]PeladaUser obj)
        {
            try
            {
                var newPeladaUser = "xico";
                //var newPeladaUser = _peladaUserService.AddUserToPelada(obj);
                return Json(newPeladaUser);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}

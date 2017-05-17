using System;
using CartolaDaPelada.Controllers;
using domain.Entities;
using domain.Services;
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
                return Json(ex);
            }
        }

        [HttpPost]
        [Route("{peladaId}/add-user")]
        public JsonResult AddUserToPelada([FromRoute]int peladaId, [FromBody]PeladaUser obj)
        {
            try
            {
                obj.PeladaId = peladaId;
                var newPeladaUser = _peladaUserService.Create(obj);
                return Json(newPeladaUser);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}

using System;
using domain.Entities;
using domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PeladaController : Controller
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
        [Route("{id}/add-user")]
        public JsonResult AddUserToPelada([FromBody]PeladaUser obj)
        {
            try
            {
                var newPeladaUser = _peladaUserService.AddUserToPelada(obj);
                return Json(newPeladaUser);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}

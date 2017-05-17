using System;
using Microsoft.AspNetCore.Mvc;
using domain.Services;
using domain.Entities;
using CartolaDaPelada.Controllers;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class ArenaController : BaseController
    {
        readonly IArenaService _arenaService;

        public ArenaController(IArenaService arenaService)
        {
            _arenaService = arenaService;
        }

        [HttpPost]
        public JsonResult Create([FromBody]Arena obj)
        {
            try
            {
                var newArena = _arenaService.Create(obj);
                return Json(newArena);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}

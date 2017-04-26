using System;
using Microsoft.AspNetCore.Mvc;
using domain.Services;
using domain.Entities;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/{controller}")]
    public class ArenaController : Controller
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

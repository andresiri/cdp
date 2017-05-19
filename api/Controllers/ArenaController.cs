using System;
using Microsoft.AspNetCore.Mvc;
using domain.Services;
using domain.Entities;
using CartolaDaPelada.Controllers;
using AutoMapper;
using api.ViewModel;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class ArenaController : BaseController
    {
        readonly IArenaService _arenaService;
        readonly IMapper _mapper;

        public ArenaController(IMapper mapper, IArenaService arenaService)
        {
            _arenaService = arenaService;
            _mapper = mapper;
        }

        [HttpPost]
        public JsonResult Create([FromBody]Arena obj)
        {
            try
            {
                var newArena = _arenaService.Create(obj);

                var arenaViewModel = _mapper.Map<ArenaViewModel>(newArena);

                return Json(newArena);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}

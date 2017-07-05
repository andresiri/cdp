using System;
using Microsoft.AspNetCore.Mvc;
using domain.Entities;
using CartolaDaPelada.Controllers;
using AutoMapper;
using api.ViewModel;
using api.Op.Arena;
using api.Context.Transaction;
using System.Collections.Generic;

namespace api.Controllers
{
    public class ArenaController : BaseController
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public ArenaController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/arenas")]
        public JsonResult Create([FromBody]Arena obj)
        {
            try
            {
                var op = new CreateArenaOp(_unitOfWork);
                var newArena = op.Execute(obj);

                var arenaViewModel = _mapper.Map<ArenaViewModel>(newArena);

                return Json(arenaViewModel);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        [Route("api/arenas")]
        public JsonResult Get([FromQuery]string description)
        {
            try
            {
                var op = new GetArenasOp(_unitOfWork);
                var arenas = op.Execute(new Arena(){Description = description}) ;

                var arenasViewModel = _mapper.Map<List<ArenaViewModel>>(arenas);

                return Json(arenasViewModel);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}

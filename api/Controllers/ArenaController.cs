using System;
using System.Collections.Generic;
using api.Context.Transaction;
using api.Op.Arena;
using api.ViewModel;
using AutoMapper;
using domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

        #region POST "api/arenas"

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

        #endregion

        #region GET "api/arenas"

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

        #endregion              
    }
}

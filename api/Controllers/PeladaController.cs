using System;
using CartolaDaPelada.Controllers;
using domain.Entities;
using domain.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using api.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    public class PeladaController : BaseController
    {
        readonly IPeladaService _peladaService;
        readonly IPeladaUserService _peladaUserService;
        readonly IMapper _mapper;

        public PeladaController(IMapper mapper, IPeladaService peladaService, IPeladaUserService peladaUserService)
        {
            _mapper = mapper;
            _peladaService = peladaService;
            _peladaUserService = peladaUserService;
        }

        [HttpPost]
        [Route("api/pelada")]
        public JsonResult Create([FromBody]Pelada obj)
        {
            try
            {
                var newPelada = _peladaService.Create(obj);

                var peladaViewModel = _mapper.Map<PeladaViewModel>(newPelada);

                return Json(peladaViewModel);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        [Authorize(Policy = "NeedsPeladaAccess")]
        [Route("api/pelada/{peladaId}/add-user")]
        public JsonResult AddUserToPelada([FromRoute]int peladaId, [FromBody]PeladaUser obj)
        {
            try
            {
                obj.PeladaId = peladaId;
                var newPeladaUser = _peladaUserService.Create(obj);

                var peladaUserViewModel = _mapper.Map<PeladaUserViewModel>(newPeladaUser);

                return Json(peladaUserViewModel);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}

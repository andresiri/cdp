using System;
using System.Collections.Generic;
using api.Context.Transaction;
using api.Op.Pelada;
using api.Op.PeladaTeam;
using api.Op.PeladaUser;
using api.ViewModel;
using AutoMapper;
using domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PeladaController : BaseController
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public PeladaController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region POST "api/peladas"

        [HttpPost]
        [Route("api/peladas")]
        public JsonResult Create([FromBody]Pelada obj)
        {
            try
            {
                var op = new CreatePeladaOp(_unitOfWork);
                var newPelada = op.Execute(obj);

                var peladaViewModel = _mapper.Map<PeladaViewModel>(newPelada);

                return Json(peladaViewModel);
            }
            catch (Exception ex)
            {
                return FormatException(ex);
            }
        }

        #endregion

        #region POST "api/peladas/{peladaId}/add-user"
        
        [HttpPost]
        [Authorize(Policy = "NeedsPeladaAccess")]
        [Route("api/peladas/{peladaId}/add-user")]
        public JsonResult AddUserToPelada([FromRoute]int peladaId, [FromBody]PeladaUser obj)
        {
            try
            {
                obj.PeladaId = peladaId;

                var op = new CreatePeladaUserOp(_unitOfWork);
                var newPeladaUser = op.Execute(obj);

                var peladaUserViewModel = _mapper.Map<PeladaUserViewModel>(newPeladaUser);

                return Json(peladaUserViewModel);
            }
            catch (Exception ex)
            {
                return FormatException(ex);
            }
        }

        #endregion

        #region POST "api/peladas/{peladId}/add-team

        [HttpPost]
        [Authorize(Policy = "NeedsPeladaAccess")]
        [Route("api/peladas/{peladaId}/add-team")]
        public JsonResult AddTeam([FromRoute]int peladaId, [FromBody]PeladaTeam obj)
        {
            try
            {
                obj.PeladaId = peladaId;

                var op = new CreatePeladaTeamOp(_unitOfWork);
                var newPeladaTeam = op.Execute(obj);

                var peladaUserViewModel = _mapper.Map<PeladaTeamViewModel>(newPeladaTeam);

                return Json(peladaUserViewModel);
            }
            catch (Exception ex)
            {
                return FormatException(ex);
            }
        }

        #endregion

        #region GET "api/peladas"

        [HttpGet]
        [Route("api/peladas")]
        public JsonResult GetPeladas() {

            try
            {
                var op = new GetPeladasByUserOp(_unitOfWork);
                var peladasUser = op.Execute(new PeladaUser{ UserId = GetUserId() });

                var peladasUserViewModel = _mapper.Map<List<PeladaUserViewModel>>(peladasUser);

                return Json(peladasUserViewModel);
            }
            catch (Exception ex)
            {
                return FormatException(ex);
            }
        }

        #endregion             
    }
}

using System;
using CartolaDaPelada.Controllers;
using domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using api.ViewModel;
using Microsoft.AspNetCore.Authorization;
using api.Context.Transaction;
using api.Op.Pelada;
using api.Op.PeladaUser;

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

        [HttpPost]
        [Route("api/pelada")]
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

        [HttpPost]
        [Authorize(Policy = "NeedsPeladaAccess")]
        [Route("api/pelada/{peladaId}/add-user")]
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
    }
}

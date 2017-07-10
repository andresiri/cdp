using System;
using api.Context.Transaction;
using api.Op.PeladaEvent;
using api.ViewModel;
using AutoMapper;
using CartolaDaPelada.Controllers;
using domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PeladaEventController : BaseController
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public PeladaEventController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Authorize(Policy = "NeedsPeladaAccess")]
        [Route("api/peladas/{peladaId}/pelada-events")]
        public JsonResult Create([FromRoute]int peladaId, [FromBody]PeladaEvent obj)
        {
            try
            {
                obj.PeladaId = peladaId;    

                var op = new CreatePeladaEventOp(_unitOfWork);
                var newPeladaEvent = op.Execute(obj);

                var peladaEventViewModel = _mapper.Map<PeladaEventViewModel>(newPeladaEvent);

                return Json(peladaEventViewModel);
            }
            catch (Exception ex)
            {
                return FormatException(ex);
            }
        }
    }
}

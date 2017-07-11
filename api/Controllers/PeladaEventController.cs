using System;
using api.Context.Transaction;
using api.Op.PeladaEvent;
using api.ViewModel;
using AutoMapper;
using domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PeladaEventController : BaseController
    {
        public readonly IMapper Mapper;
        public readonly IUnitOfWork UnitOfWork;

        public PeladaEventController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        #region POST "api/peladas/{peladaId}/pelada-events"

        [HttpPost]
        [Authorize(Policy = "NeedsPeladaAccess")]
        [Route("api/peladas/{peladaId}/pelada-events")]
        public JsonResult Create([FromRoute]int peladaId, [FromBody]PeladaEvent obj)
        {
            try
            {
                obj.PeladaId = peladaId;    

                var op = new CreatePeladaEventOp(UnitOfWork);
                var newPeladaEvent = op.Execute(obj);

                var peladaEventViewModel = Mapper.Map<PeladaEventViewModel>(newPeladaEvent);

                return Json(peladaEventViewModel);
            }
            catch (Exception ex)
            {
                return FormatException(ex);
            }
        }

        #endregion             
    }
}

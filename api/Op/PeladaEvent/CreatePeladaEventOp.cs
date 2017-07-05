﻿using api.Context.Transaction;
using FluentValidation;

namespace api.Op.PeladaEvent
{
    public class CreatePeladaEventOp : Operation<domain.Entities.PeladaEvent>
    {
        public CreatePeladaEventOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override AbstractValidator<domain.Entities.PeladaEvent> GetValidation(domain.Entities.PeladaEvent entity)
        {
            return null;
        }

        public override object Process(domain.Entities.PeladaEvent entity)
        {
            var newPeladaEvent = _unitOfWork.PeladaEventRepository.Create(entity);

            return newPeladaEvent;
        }
    }
}

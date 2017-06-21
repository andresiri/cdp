﻿using api.Context.Transaction;
using FluentValidation;

namespace api.Op.PeladaUser
{
    public class GetPeladasByUserOp : Operation<domain.Entities.PeladaUser>
    {
        readonly IUnitOfWork _unitOfWork;

        public GetPeladasByUserOp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override AbstractValidator<domain.Entities.PeladaUser> GetValidation(domain.Entities.PeladaUser entity)
        {
            return null;
        }

        public override object Process(domain.Entities.PeladaUser entity)
        {
            var peladasUser = _unitOfWork.PeladaUserRepository.GetPeladasByUser(entity.UserId);
            return peladasUser;
        }
    }
}
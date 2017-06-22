﻿using api.Context.Transaction;
using FluentValidation;
using System.Linq;

namespace api.Op.Arena
{
    public class GetArenasOp : Operation<domain.Entities.Arena>
    {
        public GetArenasOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override AbstractValidator<domain.Entities.Arena> GetValidation(domain.Entities.Arena entity)
        {
            return null;
        }

        public override object Process(domain.Entities.Arena entity)
        {
            var arenas = _unitOfWork.ArenaRepository.DbSet.Where(w => 
                    w.Description.Contains(entity.Description) || string.IsNullOrEmpty(entity.Description)
                ).ToList();

            return arenas;
        }
    }
}

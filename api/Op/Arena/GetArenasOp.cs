using api.Context.Transaction;
using FluentValidation;

namespace api.Op.Arena
{
    public class GetArenasOp : Operation<domain.Entities.Arena>
    {
        readonly IUnitOfWork _unitOfWork;

        public GetArenasOp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override AbstractValidator<domain.Entities.Arena> GetValidation(domain.Entities.Arena entity)
        {
            return null;
        }

        public override object Process(domain.Entities.Arena entity)
        {
            var arenas = _unitOfWork.ArenaRepository.GetAll();

            return arenas;
        }
    }
}

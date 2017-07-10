using api.Context.Transaction;
using domain.Entities.Validations.Arena;
using FluentValidation;

namespace api.Op.Arena
{
    public class CreateArenaOp : Operation<domain.Entities.Arena>
    {
        public CreateArenaOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override AbstractValidator<domain.Entities.Arena> GetValidation(domain.Entities.Arena entity)
        {
            return new CreateArenaValidation();
        }

        public override object Process(domain.Entities.Arena entity)
        {
            var newArena = _unitOfWork.ArenaRepository.Create(entity);

            return newArena;
        }
    }
}

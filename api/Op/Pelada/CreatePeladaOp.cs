using api.Context.Transaction;
using domain.Entities.Validations.Pelada;
using FluentValidation;

namespace api.Op.Pelada
{
    public class CreatePeladaOp : Operation<domain.Entities.Pelada>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreatePeladaOp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override AbstractValidator<domain.Entities.Pelada> GetValidation(domain.Entities.Pelada entity)
        {
            return new CreatePeladaValidation();
        }

        public override object Process(domain.Entities.Pelada entity)
        {
            var newPelada = _unitOfWork.PeladaRepository.Create(entity);
            _unitOfWork.Save();

            return newPelada;
        }
    }
}

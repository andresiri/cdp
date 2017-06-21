using api.Context.Transaction;
using domain.Entities.Validations.PeladaUser;
using FluentValidation;

namespace api.Op.PeladaUser
{
    public class CreatePeladaUserOp : Operation<domain.Entities.PeladaUser>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreatePeladaUserOp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override AbstractValidator<domain.Entities.PeladaUser> GetValidation(domain.Entities.PeladaUser entity)
        {
            return new CreatePeladaUserValidation();
        }

        public override object Process(domain.Entities.PeladaUser entity)
        {
            var newPeladaUser = _unitOfWork.PeladaUserRepository.Create(entity);
            _unitOfWork.Save();

            return newPeladaUser;
        }
    }
}

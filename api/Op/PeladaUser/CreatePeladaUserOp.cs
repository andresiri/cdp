using api.Context.Transaction;
using FluentValidation;

namespace api.Op.PeladaUser
{
    public class CreatePeladaUserOp : Operation<domain.Entities.PeladaUser>
    {
        public CreatePeladaUserOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override AbstractValidator<domain.Entities.PeladaUser> GetValidation(domain.Entities.PeladaUser entity)
        {
            return new CreatePeladaUserValidation();
        }

        public override object Process(domain.Entities.PeladaUser entity)
        {
            var newPeladaUser = _unitOfWork.PeladaUserRepository.Create(entity);

            return newPeladaUser;
        }
    }
    
    public class CreatePeladaUserValidation : AbstractValidator<domain.Entities.PeladaUser>
    {
        public CreatePeladaUserValidation()
        {
            RuleFor(peladaUser => peladaUser.UserId).NotEmpty();
            RuleFor(peladaUser => peladaUser.PeladaId).NotEmpty();
        }
    }
}

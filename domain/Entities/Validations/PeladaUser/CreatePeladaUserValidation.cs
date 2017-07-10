using FluentValidation;

namespace domain.Entities.Validations.PeladaUser
{
    public class CreatePeladaUserValidation : AbstractValidator<Entities.PeladaUser>
    {
        public CreatePeladaUserValidation()
        {
            RuleFor(peladaUser => peladaUser.UserId).NotEmpty();
            RuleFor(peladaUser => peladaUser.PeladaId).NotEmpty();
        }
    }
}

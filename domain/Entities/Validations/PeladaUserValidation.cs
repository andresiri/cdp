using FluentValidation;
namespace domain.Entities.Validations
{
    public class PeladaUserValidation : AbstractValidator<PeladaUser>
    {
        public PeladaUserValidation()
        {
            RuleFor(pu => pu.UserId).NotEmpty();
            RuleFor(pu => pu.PeladaId).NotEmpty();
        }
    }
}

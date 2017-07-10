using FluentValidation;

namespace domain.Entities.Validations.Pelada
{
    public class CreatePeladaValidation : AbstractValidator<Entities.Pelada>
    {
        public CreatePeladaValidation()
        {
            RuleFor(pelada => pelada.Name).NotEmpty();
            RuleFor(pelada => pelada.Day).NotEmpty();
        }
    }
}

using FluentValidation;
namespace domain.Entities.Validations.Arena
{
    public class CreateArenaValidation : AbstractValidator<Entities.Arena>
    {
        public CreateArenaValidation()
        {
            RuleFor(arena => arena.Name).NotEmpty();
            RuleFor(arena => arena.Description).NotEmpty();
        }
    }
}

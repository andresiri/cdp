using domain.Entities.Model;
using FluentValidation;

namespace domain.Entities.Validations.Login
{
    public class LoginValidation : AbstractValidator<LoginModel>
    {
        public LoginValidation()
        {
            RuleFor(login => login.Email).NotEmpty().EmailAddress();
            RuleFor(login => login.Password).NotEmpty();
        }
    }
}

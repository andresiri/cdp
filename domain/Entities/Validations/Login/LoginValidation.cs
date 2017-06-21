using System;
using FluentValidation;

namespace domain.Entities.Validations.Login
{
    public class LoginValidation : AbstractValidator<Entities.Model.LoginModel>
    {
        public LoginValidation()
        {
            RuleFor(login => login.Email).NotEmpty().EmailAddress();
            RuleFor(login => login.Password).NotEmpty();
        }
    }
}

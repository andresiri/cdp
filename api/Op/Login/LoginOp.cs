using api.Context.Transaction;
using domain.Entities.Validations.Login;
using domain.Enum;
using domain.Exceptions;
using domain.Lib;
using domain.Models;
using FluentValidation;

namespace api.Op.Login
{
    public class LoginOp : Operation<LoginModel>
    {
        public LoginOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override AbstractValidator<LoginModel> GetValidation(LoginModel entity)
        {
            return new LoginValidation();
        }

        public override object Process(LoginModel entity)
        {
            var user = _unitOfWork.UserRepository.GetByEmailAddress(entity.Email);

            if (user != null)
            {
                var hashPassword = Password.Hash(entity.Password, entity.Email);

                if (hashPassword.Equals(user.Password))
                {
                    return user;
                }

                throw new CustomException(ExceptionMessage.INVALID_USERNAME_PASSWORD, ExceptionType.LOGIN_ERROR);
            }

            throw new CustomException(ExceptionMessage.INVALID_USERNAME_PASSWORD, ExceptionType.LOGIN_ERROR);
        }
    }
}

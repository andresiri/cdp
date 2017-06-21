using api.Context.Transaction;
using domain.Entities.Exceptions;
using domain.Lib;
using domain.Entities.Enum;
using FluentValidation;
using domain.Entities.Validations.User;

namespace api.Op.User
{
    public class CreateUserOp : Operation<domain.Entities.User>
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateUserOp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override AbstractValidator<domain.Entities.User> GetValidation(domain.Entities.User entity)
        {
            return new CreateUserValidation();
        }

        public override object Process(domain.Entities.User entity)
        {            
            var existentUser = _unitOfWork.UserRepository.GetByEmailAddress(entity.Email.Trim());

            if (existentUser != null)
            {
                throw new CustomException(ExceptionMessage.EMAIL_ALREADY_IN_USE, ExceptionType.CUSTOM_ERROR);
            }

            entity.Password = Password.Hash(entity.Password, entity.Email);

            var newUser = _unitOfWork.UserRepository.Create(entity);
            _unitOfWork.Save();

            return newUser;
        }
    }
}

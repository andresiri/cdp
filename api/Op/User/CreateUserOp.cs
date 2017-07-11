using api.Context.Transaction;
using domain.Enum;
using domain.Exceptions;
using domain.Lib;
using FluentValidation;

namespace api.Op.User
{
    public class CreateUserOp : Operation<domain.Entities.User>
    {
        public CreateUserOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
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

            return newUser;
        }
    }
    
    public class CreateUserValidation : AbstractValidator<domain.Entities.User>
    {
        public CreateUserValidation()
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress().Length(1, 100);
            RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.FirstName).NotEmpty().Length(1, 100);
            RuleFor(user => user.LastName).NotEmpty().Length(1, 100);
        }
    }
}

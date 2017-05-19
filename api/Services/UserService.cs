using System;
using api.Context.Transaction;
using domain.Entities;
using domain.Lib;
using domain.Services;
using domain.Entities.Exceptions;
using domain.Entities.Enum;

namespace api.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User Create(User obj)
        {
            try
            {
                obj.Validate();

                var existentUser = _unitOfWork.UserRepository.GetByEmailAddress(obj.Email.Trim());

                if (existentUser != null)
                {
                    throw new CustomException(ExceptionMessage.EMAIL_ALREADY_IN_USE, ExceptionType.CUSTOM_ERROR);
                }

                obj.Password = Password.Hash(obj.Password, obj.Email);

                var newUser = _unitOfWork.UserRepository.Create(obj);
                _unitOfWork.Save();

                return newUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int userId)
        {
            try
            {
                _unitOfWork.UserRepository.Delete(userId);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
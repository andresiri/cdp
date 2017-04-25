using System;
using api.Context.Transaction;
using domain.Services;
using Domain.Entities;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Create(User obj)
        {
            try
            {
                obj.Validate();

//                var existentUser = _unitOfWork.UserRepository.GetByEmailAddress(obj.Email);
//
//                if (existentUser != null)
//                {
//                    throw new Exception("Email already in use.");
//                }

//                obj.Password = Password.hash(obj.Password, obj.Email);

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
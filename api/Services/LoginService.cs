using System;
using api.Context.Transaction;
using domain.Entities;
using domain.Lib;
using domain.Services;

namespace api.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Login(string email, string password)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetByEmailAddress(email);

                if (user != null)
                {
                    var hashPassword = Password.Hash(password, email);

                    if (hashPassword.Equals(user.Password))
                    {
                        return user;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

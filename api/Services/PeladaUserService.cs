using System;
using System.Collections.Generic;
using api.Context.Transaction;
using domain.Entities;
using domain.Services;

namespace api.Services
{
    public class PeladaUserService : BaseService, IPeladaUserService
    {
        public PeladaUserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public PeladaUser Create(PeladaUser obj)
        {
            try 
            {
                obj.Validate();

                var newPeladaUser = _unitOfWork.PeladaUserRepository.Create(obj);
                _unitOfWork.Save();

                newPeladaUser.Pelada = null;
                newPeladaUser.User = null;

                return newPeladaUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PeladaUser> GetPeladasByUser(int userId)
        {
            try 
            {
                var peladasUser = _unitOfWork.PeladaUserRepository.GetPeladasByUser(userId);
                return peladasUser;
            }
            catch(Exception ex) {

                throw ex;
            }
        }
    }
}

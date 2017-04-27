using System;
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

        public PeladaUser AddUserToPelada(PeladaUser obj)
        {
            throw new NotImplementedException();
        }
    }
}

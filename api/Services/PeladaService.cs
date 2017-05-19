using System;
using api.Context.Transaction;
using domain.Entities;
using domain.Services;
using domain.Entities.Exceptions;

namespace api.Services
{
    public class PeladaService : BaseService, IPeladaService
    {
        public PeladaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Pelada Create(Pelada obj)
        {
            try 
            {
                obj.Validate();

                var newPelada = _unitOfWork.PeladaRepository.Create(obj);
                _unitOfWork.Save();

                return newPelada;
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}

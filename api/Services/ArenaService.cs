using System;
using api.Context.Transaction;
using domain.Entities;
using domain.Services;
using Remotion.Linq.Parsing;

namespace api.Services
{
    public class ArenaService : IArenaService
    {
        readonly IUnitOfWork _unitOfWork;

        public ArenaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Arena Create(Arena obj)
        {                      
            try 
            {
                obj.Validate();

                var newArena = _unitOfWork.ArenaRepository.Create(obj);
                _unitOfWork.Save();

                return newArena;
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}

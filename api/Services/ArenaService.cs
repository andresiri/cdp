using System;
using api.Context.Transaction;
using domain.Entities;
using domain.Services;
using Remotion.Linq.Parsing;

namespace api.Services
{
    public class ArenaService : BaseService, IArenaService
    {
        public ArenaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
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

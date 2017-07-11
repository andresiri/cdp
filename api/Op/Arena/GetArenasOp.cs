using System.Linq;
using api.Context.Transaction;
using FluentValidation;

namespace api.Op.Arena
{
    public class GetArenasOp : Operation<domain.Entities.Arena>
    {
        public GetArenasOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }       

        public override object Process(domain.Entities.Arena entity)
        {
            var arenas = _unitOfWork.ArenaRepository.DbSet.Where(w => 
                    w.Description.Contains(entity.Description) || string.IsNullOrEmpty(entity.Description)
                ).ToList();

            return arenas;
        }
    }
}

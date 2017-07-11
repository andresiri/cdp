using api.Context.Transaction;
using FluentValidation;

namespace api.Op.PeladaTeam
{
    public class CreatePeladaTeamOp : Operation<domain.Entities.PeladaTeam>
    {
        public CreatePeladaTeamOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }       

        public override object Process(domain.Entities.PeladaTeam entity)
        {
            var newPeladaTeam = _unitOfWork.PeladaTeamRepository.Create(entity);

            return newPeladaTeam;
        }
    }
}
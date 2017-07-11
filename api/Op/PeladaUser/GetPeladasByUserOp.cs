using api.Context.Transaction;
using FluentValidation;

namespace api.Op.PeladaUser
{
    public class GetPeladasByUserOp : Operation<domain.Entities.PeladaUser>
    {
        public GetPeladasByUserOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }        

        public override object Process(domain.Entities.PeladaUser entity)
        {
            var peladasUser = _unitOfWork.PeladaUserRepository.GetPeladasByUser(entity.UserId);
            return peladasUser;
        }
    }
}

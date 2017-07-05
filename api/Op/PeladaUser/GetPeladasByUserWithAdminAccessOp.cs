using api.Context.Transaction;
using FluentValidation;

namespace api.Op.PeladaUser
{
    public class GetPeladasByUserWithAdminAccessOp : Operation<domain.Entities.PeladaUser>
    {
        public GetPeladasByUserWithAdminAccessOp(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override AbstractValidator<domain.Entities.PeladaUser> GetValidation(domain.Entities.PeladaUser entity)
        {
            return null;
        }

        public override object Process(domain.Entities.PeladaUser entity)
        {
            var peladasUser = _unitOfWork.PeladaUserRepository.GetPeladasByUserWithAdminAccess(entity.UserId);
            return peladasUser;
        }
    }
}

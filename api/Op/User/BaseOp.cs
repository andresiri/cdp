using api.Context.Transaction;
using domain;
namespace api.Op.User
{
    public abstract class BaseOp : Operation
    {
        protected IUnitOfWork _unitOfWork;

        public BaseOp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

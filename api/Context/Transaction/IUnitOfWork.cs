using api.Context.Repository;

namespace api.Context.Transaction
{
    public interface IUnitOfWork
    {
        void Save();
        void Commit();
        void Rollback();

        UserRepository UserRepository { get; }
    }
}
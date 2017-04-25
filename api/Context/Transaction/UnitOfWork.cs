using api.Context.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace api.Context.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        protected CdpContext context;
        private readonly IDbContextTransaction transaction;

        public UnitOfWork(CdpContext _context)
        {
            context = _context;
            transaction = context.Database.BeginTransaction();
        }

        private UserRepository userRepository;
        public UserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(context));

        public void Save()
        {
            Commit();
            context.SaveChanges();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}
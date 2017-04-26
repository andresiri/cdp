using api.Context.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace api.Context.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        protected CdpContext context;
        readonly IDbContextTransaction transaction;

        public UnitOfWork(CdpContext _context)
        {
            context = _context;
            transaction = context.Database.BeginTransaction();
        }

        UserRepository userRepository;
        public UserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(context));

        ArenaRepository arenaRepository;
        public ArenaRepository ArenaRepository => arenaRepository ?? (arenaRepository = new ArenaRepository(context));

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
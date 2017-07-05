using api.Context.Repository;
using Microsoft.EntityFrameworkCore;

namespace api.Context.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        protected CdpContext context;
        //readonly IDbContextTransaction transaction;

        UserRepository userRepository;
        ArenaRepository arenaRepository;
        PeladaRepository peladaRepository;
        PeladaUserRepository peladaUserRepository;
        PeladaEventRepository peladaEventRepository;

        public UnitOfWork(CdpContext _context)
        {
            context = _context;
            //transaction = context.Database.BeginTransaction();
        }

        public UserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(context));
        public ArenaRepository ArenaRepository => arenaRepository ?? (arenaRepository = new ArenaRepository(context));
        public PeladaRepository PeladaRepository => peladaRepository ?? (peladaRepository = new PeladaRepository(context));
        public PeladaUserRepository PeladaUserRepository => peladaUserRepository ?? (peladaUserRepository = new PeladaUserRepository(context));
        public PeladaEventRepository PeladaEventRepository => peladaEventRepository ?? (peladaEventRepository = new PeladaEventRepository(context));

        public void Save()
        {
            //transaction.Commit();
            context.SaveChanges();
            context.Database.CloseConnection();
        }

        public void Rollback()
        {
            //transaction.Rollback();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
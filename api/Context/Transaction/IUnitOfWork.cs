using api.Context.Repository;
using System;

namespace api.Context.Transaction
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Rollback();

        UserRepository UserRepository { get; }
        ArenaRepository ArenaRepository { get; }
        PeladaRepository PeladaRepository { get; }
        PeladaUserRepository PeladaUserRepository { get; }
    }
}
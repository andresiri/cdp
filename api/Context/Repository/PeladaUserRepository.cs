using System;
using domain.Entities;
using domain.Repositories;

namespace api.Context.Repository
{
    public class PeladaUserRepository : BaseRepository<PeladaUser>, IPeladaUserRepository
    {
        public PeladaUserRepository(CdpContext context) : base(context)
        {
        }
    }
}

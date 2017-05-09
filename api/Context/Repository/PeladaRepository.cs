using domain.Entities;
using domain.Repositories;
using System.Collections.Generic;

namespace api.Context.Repository
{
    public class PeladaRepository : BaseRepository<Pelada>, IPeladaRepository
    {
        public PeladaRepository(CdpContext context) : base(context)
        {
        }
    }
}

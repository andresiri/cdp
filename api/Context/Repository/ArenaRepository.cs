using domain.Entities;
using domain.Repositories;

namespace api.Context.Repository
{
    public class ArenaRepository : BaseRepository<Arena>, IArenaRepository
	{
        public ArenaRepository(CdpContext context) : base(context)
		{
		}
	}
}

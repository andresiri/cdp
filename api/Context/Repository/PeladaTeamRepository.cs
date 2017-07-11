using domain.Entities;
using domain.Repositories;

namespace api.Context.Repository
{
    public class PeladaTeamRepository : BaseRepository<PeladaTeam>, IPeladaTeamRepository
    {
        public PeladaTeamRepository(CdpContext context) : base(context)
        {
        }
    }
}
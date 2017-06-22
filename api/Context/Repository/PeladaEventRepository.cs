using domain.Entities;
using domain.Repositories;
namespace api.Context.Repository
{
    public class PeladaEventRepository : BaseRepository<PeladaEvent>, IPeladaEventRepository
    {
        public PeladaEventRepository(CdpContext context) : base(context)
        {
        }
    }
}

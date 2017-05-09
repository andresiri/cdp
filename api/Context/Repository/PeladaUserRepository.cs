using System.Collections.Generic;
using domain.Entities;
using domain.Repositories;
using System.Linq;

namespace api.Context.Repository
{
    public class PeladaUserRepository : BaseRepository<PeladaUser>, IPeladaUserRepository
    {
        public PeladaUserRepository(CdpContext context) : base(context)
        {
        }

        public List<PeladaUser> GetPeladasByUser(int userId)
        {
            var peladasUser = _context.PeladaUser.Where(w => w.UserId.Equals(userId)).ToList();

            return peladasUser;
        }
    }
}

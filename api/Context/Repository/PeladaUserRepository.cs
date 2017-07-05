using System.Collections.Generic;
using domain.Entities;
using domain.Repositories;
using System.Linq;
using System;

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

        public List<PeladaUser> GetPeladasByUserWithAdminAccess(int userId)
        {
            var peladasUser = _context.PeladaUser.Where(
                w => w.UserId.Equals(userId) && w.IsAdministrator.Equals(true)
            ).ToList();

            return peladasUser;
        }
    }
}

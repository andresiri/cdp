using System.Collections.Generic;
using domain.Entities;

namespace domain.Repositories
{
    public interface IPeladaUserRepository : IBaseRepository<PeladaUser>
    {
        List<PeladaUser> GetPeladasByUser(int userId);
        List<PeladaUser> GetPeladasByUserWithAdminAccess(int userId);
    }
}

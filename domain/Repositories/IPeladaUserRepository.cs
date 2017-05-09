using domain.Entities;
using System.Collections.Generic;

namespace domain.Repositories
{
    public interface IPeladaUserRepository : IBaseRepository<PeladaUser>
    {
        List<PeladaUser> GetPeladasByUser(int userId);
    }
}

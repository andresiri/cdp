using domain.Entities;
using System.Collections.Generic;

namespace domain.Services
{
    public interface IPeladaUserService
    {
        PeladaUser Create(PeladaUser obj);
        List<PeladaUser> GetPeladasByUser(int userId);
    }
}

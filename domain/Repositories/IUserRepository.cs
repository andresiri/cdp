using domain.Entities;

namespace domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void Delete(int userId);
    }

}
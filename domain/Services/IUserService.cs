using domain.Entities;

namespace domain.Services
{
    public interface IUserService
    {
        User Create(User obj);
        void Delete(int userId);
    }
}
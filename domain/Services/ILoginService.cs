using domain.Entities;

namespace domain.Services
{
    public interface ILoginService
    {
        User Login(string email, string password);
    }
}

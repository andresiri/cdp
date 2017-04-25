using System.Linq;
using domain.Repositories;
using Domain.Entities;

namespace api.Context.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CdpContext context) : base(context)
        {
        }

        public void Delete(int userId)
        {
            var user = GetById(userId);

            if (user != null)
            {
                _context.User.Remove(user);
            }
        }

        public User GetById(int userId)
        {
            var user = _context.User.FirstOrDefault(w => w.Id.Equals(userId));

            return user;
        }

        public User GetByEmailAddress(string emailAddress)
        {
            emailAddress = emailAddress.Trim();
            var user = _context.User.FirstOrDefault(u => u.Email.Equals(emailAddress));
            return user;
        }
    }

}
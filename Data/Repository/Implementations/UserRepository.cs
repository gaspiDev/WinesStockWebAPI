using Data.Entities;
using Common.Models;
using Data.Repository.Interfaces;

namespace Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly WinesStockContext _context;
        public UserRepository(WinesStockContext winesStockContext)
        {
            _context = winesStockContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User? ValidateUser(CredentialsDTO credentialsDTO)
        {
            return _context.Users.FirstOrDefault(u => u.Username == credentialsDTO.UserName && u.Password == credentialsDTO.Password);
        }
        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return _context.Users.Max(u => u.Id);
        }
    }
}

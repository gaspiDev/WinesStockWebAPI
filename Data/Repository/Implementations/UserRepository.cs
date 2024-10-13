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
        public IEnumerable<User> ReadUsers()
        {
            return _context.Users.ToList();
        }
        public User? AuthUser(CredentialsDto credentialsDto)
        {
            return _context.Users.FirstOrDefault(u => u.Username == credentialsDto.UserName && u.Password == credentialsDto.Password);
        }
        public int CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return _context.Users.Max(u => u.Id);
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }
    }
}

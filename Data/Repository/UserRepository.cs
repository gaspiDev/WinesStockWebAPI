using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly WinesStockContext _context;
        public UserRepository(WinesStockContext winesStockContext)
        {
            _context = winesStockContext;
        }
        public List<User> GetUsers()
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

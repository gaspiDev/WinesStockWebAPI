using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Data.Repository
{
    public class UserHardCodedDBRepository : IUserHardCodedDBRepository
    {

        private List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                Username = "johndoe",
                Password = "P@ssw0rd123"
            },
            new User
            {
                Id = 2,
                Username = "janedoe",
                Password = "Secr3tPass!"
            },
            new User
            {
                Id = 3,
                Username = "adminuser",
                Password = "Admin2024!"
            }
        };
        public List<User> GetUsers()
        { 
            return users;
        }

        public User? ValidateUser(CredentialsDTO credentialsDTO) 
        {
            return GetUsers().FirstOrDefault(u => u.Username == credentialsDTO.UserName && u.Password == credentialsDTO.Password);
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
    }
}

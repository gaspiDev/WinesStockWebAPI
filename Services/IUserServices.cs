using Common.Models;
using Data.Entities;

namespace Services
{
    public interface IUserServices
    {
        public User? ValidateUser(CredentialsDTO credentialsDTO);
        void AddUser(CreateUserDTO createUserDTO);
    }
}
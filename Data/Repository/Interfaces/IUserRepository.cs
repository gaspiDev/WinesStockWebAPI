using Common.Models;
using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        User? ValidateUser(CredentialsDTO credentialsDTO);
        IEnumerable<User> GetUsers();
        int AddUser(User user);
    }
}
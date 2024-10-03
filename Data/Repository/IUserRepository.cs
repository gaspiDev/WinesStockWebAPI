using Common.Models;
using Data.Entities;

namespace Data.Repository
{
    public interface IUserRepository
    {
        User? ValidateUser(CredentialsDTO credentialsDTO);
        List<User> GetUsers();
        int AddUser(User user);
    }
}
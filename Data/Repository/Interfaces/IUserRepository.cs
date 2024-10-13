using Common.Models;
using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        User? AuthUser(CredentialsDto credentialsDTO);
        IEnumerable<User> ReadUsers();
        int CreateUser(User user);
    }
}
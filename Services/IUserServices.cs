using Common.Models;
using Data.Entities;

namespace Services
{
    public interface IUserServices
    {
        User? ValidateUser(CredentialsDTO credentialsDTO);
        int AddUser(CreateUserDTO createUserDTO);
    }
}
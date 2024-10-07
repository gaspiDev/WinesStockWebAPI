using Common.Models;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        User? ValidateUser(CredentialsDTO credentialsDTO);
        int AddUser(CreateUserDTO createUserDTO);
    }
}
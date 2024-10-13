using Common.Models;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        User? AuthUser(CredentialsDto credentialsDTO);
        int CreateUser(NewUserDto createUserDTO);
    }
}
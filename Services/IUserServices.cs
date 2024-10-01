using Common.Models;

namespace Services
{
    public interface IUserServices
    {
        void AddUser(CreateUserDTO createUserDTO);
    }
}
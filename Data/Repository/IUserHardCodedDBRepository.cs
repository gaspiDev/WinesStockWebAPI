using Common.Models;
using Data.Entities;

namespace Data.Repository
{
    public interface IUserHardCodedDBRepository
    {
        public User? ValidateUser(CredentialsDTO credentialsDTO);
        public List<User> GetUsers();
        void AddUser(User user);
    }
}
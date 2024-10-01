using Data.Entities;

namespace Data.Repository
{
    public interface IUserHardCodedDBRepository
    {
        public List<User> GetUsers();
        void AddUser(User user);
    }
}
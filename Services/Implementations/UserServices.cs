using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserServices : IUserServices
    {
        public readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User? ValidateUser(CredentialsDTO credentialsDTO)
        {
            return _userRepository.ValidateUser(credentialsDTO);
        }

        public int AddUser(CreateUserDTO createUserDTO)
        {
            if (_userRepository.GetUsers().All(user => user.Username != createUserDTO.Username))
            {
                int newUserId = _userRepository.AddUser(
                    new User
                    {
                        Id = _userRepository.GetUsers().Max(x => x.Id) + 1,
                        Username = createUserDTO.Username,
                        Password = createUserDTO.Password
                    }
                    );
                return newUserId;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}

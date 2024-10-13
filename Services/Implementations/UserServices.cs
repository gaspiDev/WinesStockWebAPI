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
        public User? AuthUser(CredentialsDto credentialsDto)
        {
            return _userRepository.AuthUser(credentialsDto);
        }

        public int CreateUser(NewUserDto newUserDto)
        {
            if (_userRepository.ReadUsers().All(user => user.Username != newUserDto.Username))
            {
                try
                {
                    int newUserId = _userRepository.CreateUser(
                        new User
                        {
                            Id = _userRepository.ReadUsers().Max(x => x.Id) + 1,
                            Username = newUserDto.Username,
                            Password = newUserDto.Password
                        }
                        );
                    return newUserId;
                }
                catch (Exception) 
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}

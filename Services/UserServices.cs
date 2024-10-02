using Common.Models;
using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        public readonly IUserHardCodedDBRepository _userHardCodedDBRepository;
        public UserServices(IUserHardCodedDBRepository userHardCodedDBRepository)
        {
            _userHardCodedDBRepository = userHardCodedDBRepository;
        }
        public User? ValidateUser(CredentialsDTO credentialsDTO) 
        {
            return _userHardCodedDBRepository.ValidateUser(credentialsDTO);    
        }

        public void AddUser(CreateUserDTO createUserDTO)
        {
            if (_userHardCodedDBRepository.GetUsers().All(user => user.Username != createUserDTO.Username))
            {
                _userHardCodedDBRepository.AddUser(
                    new User
                    {
                        Id = _userHardCodedDBRepository.GetUsers().Max(x => x.Id) + 1,
                        Username = createUserDTO.Username,
                        Password = createUserDTO.Password
                    }
                    );
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}

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
    public class UserServices
    {
        public readonly UserHardCodedDBRepository _userHardCodedDBRepository;
        public UserServices(UserHardCodedDBRepository userHardCodedDBRepository)
        { 
            _userHardCodedDBRepository = userHardCodedDBRepository;
        }

        public void AddUser(CreateUserDTO createUserDTO)
        {
            if (_userHardCodedDBRepository.users.All(user => user.Username != createUserDTO.Username))
            {
                _userHardCodedDBRepository.AddUser(
                    new User
                    {
                        Id = _userHardCodedDBRepository.users.Max(x => x.Id) + 1,
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

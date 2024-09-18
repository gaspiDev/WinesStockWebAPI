using Common;
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
        public readonly HardCodedDBRepository _hardCodedDBRepository;
        public UserServices(HardCodedDBRepository hardCodedDBRepository)
        {
            _hardCodedDBRepository = hardCodedDBRepository;
        }

        public void AddUser(CreateUserDTO createUserDTO)
        {
            _hardCodedDBRepository.AddUser(
                new User
                {
                    Id = _hardCodedDBRepository.users.Max(x => x.Id) + 1,
                    Username = createUserDTO.Username,
                    Password = createUserDTO.Password
                }    
                );
        }
    }
}

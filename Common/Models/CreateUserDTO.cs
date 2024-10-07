using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class CreateUserDTO
    {
        public string Username { get; set; }
        [MinLength(10)]
        public string Password { get; set; }
    }
}

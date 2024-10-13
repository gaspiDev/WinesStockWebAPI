using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class NewUserDto
    {
        public required string Username { get; set; }

        [MinLength(8)]
        public required string Password { get; set; }
    }
}

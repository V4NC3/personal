using System.ComponentModel.DataAnnotations;

namespace server.Models.DataModels
{
    public class UserLoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
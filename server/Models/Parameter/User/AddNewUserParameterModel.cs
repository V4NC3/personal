using System.ComponentModel.DataAnnotations;

namespace server.Models.Parameter.User
{
    public class AddNewUserParameterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
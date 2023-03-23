using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Request
{
    public class CreateUserRequest
    {

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_]{2,50}$", 
            ErrorMessage = "User name must only include alphanumeric charachters and \'_\' and have at least 2, at most 50 characters.")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        public string Password { get; set; }

    }
}

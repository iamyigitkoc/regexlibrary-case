using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Request
{
    public class AuthRequest
    {

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_]{2,50}$",
            ErrorMessage = "Invalid username")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        public string Password { get; set; }

    }
}

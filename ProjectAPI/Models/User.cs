using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Uniqueness and validity of username tested on service layer
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(512)]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }

    }
}

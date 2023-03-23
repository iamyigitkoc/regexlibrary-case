using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Request
{
    public class CreateRegexRequest
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Pattern { get; set; }

        public string Description { get; set; }

    }
}

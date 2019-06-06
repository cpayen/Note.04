using System.ComponentModel.DataAnnotations;

namespace Note.Api.DTO.Space
{
    public class UpdateSpaceDTO
    {
        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Required, MaxLength(100), RegularExpression("^[a-z0-9-]+$", ErrorMessage = "Invalid chars in slug")]
        public string Slug { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }
    }
}

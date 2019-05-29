using System;
using System.ComponentModel.DataAnnotations;

namespace Note.Api.DTO.Space
{
    public class CreateSpaceDTO
    {
        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Required, MaxLength(100), RegularExpression(@"^[a-z0-9\-]+$", ErrorMessage = "Invalid chars in slug")]
        public string Slug { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required, RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Invalid color format")]
        public string Color { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}

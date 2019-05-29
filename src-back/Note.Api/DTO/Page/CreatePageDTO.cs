using System;
using System.ComponentModel.DataAnnotations;

namespace Note.Api.DTO.Page
{
    public class CreatePageDTO
    {
        [Required, MaxLength(250)]
        public string Title { get; set; }

        [Required, MaxLength(100), RegularExpression(@"^[a-z0-9\-]+$", ErrorMessage = "Invalid chars in slug")]
        public string Slug { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public string Content { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}

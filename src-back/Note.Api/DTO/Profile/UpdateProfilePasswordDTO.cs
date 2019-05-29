using System.ComponentModel.DataAnnotations;

namespace Note.Api.DTO.Profile
{
    public class UpdateProfilePasswordDTO
    {
        [Required]
        public string Password { get; set; }
    }
}

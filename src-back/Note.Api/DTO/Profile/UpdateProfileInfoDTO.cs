using System.ComponentModel.DataAnnotations;

namespace Note.Api.DTO.Profile
{
    public class UpdateProfileInfoDTO
    {
        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}

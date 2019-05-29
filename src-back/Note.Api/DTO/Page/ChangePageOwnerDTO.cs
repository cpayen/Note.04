using System;
using System.ComponentModel.DataAnnotations;

namespace Note.Api.DTO.Page
{
    public class ChangePageOwnerDTO
    {
        [Required]
        public Guid OwnerId { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Note.Api.DTO.Space
{
    public class ChangeSpaceOwnerDTO
    {
        [Required]
        public Guid OwnerId { get; set; }
    }
}

﻿using Note.Api.DTO.AppUser;
using System;

namespace Note.Api.DTO.Page
{
    public class PageLightDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public AppUserLightDTO Owner { get; set; }
    }
}

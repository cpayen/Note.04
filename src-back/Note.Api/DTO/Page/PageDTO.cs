using Note.Api.DTO.Space;

namespace Note.Api.DTO.Page
{
    public class PageDTO : PageLightDTO
    {
        public string Content { get; set; }
        public SpaceLightDTO Space { get; set; }
    }
}

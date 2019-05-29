using Note.Api.DTO.Page;
using System.Collections.Generic;

namespace Note.Api.DTO.Space
{
    public class SpaceDTO : SpaceLightDTO
    {
        public List<PageLightDTO> Pages { get; set; }
    }
}

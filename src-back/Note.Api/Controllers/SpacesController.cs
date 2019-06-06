using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Note.Api.DTO;
using Note.Api.DTO.Space;
using Note.Core.Identity;
using Note.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Api.Controllers
{
    [Route("api/spaces")]
    [ApiController]
    [Authorize]
    public class SpacesController : ControllerBase
    {
        protected readonly Spaces _spaces;
        protected readonly ICurrentUserInfos _currentUserInfo;

        public SpacesController(Spaces spaces, ICurrentUserInfos currentUserInfo)
        {
            _spaces = spaces;
            _currentUserInfo = currentUserInfo;
        }

        // GET api/spaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpaceLightDTO>>> GetAsync()
        {
            var items = await _spaces.GetAllAsync();
            var dto = items.Select(o => Mappers.GetSpaceLightDTO(o)).ToList();
            return Ok(dto);
        }

        // GET api/spaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpaceDTO>> FindAsync(string id)
        {
            Guid guidId;
            bool isGuid = Guid.TryParse(id, out guidId);
            var item = isGuid ? await _spaces.FindAsync(guidId) : await _spaces.FindAsync(id);
            return Ok(Mappers.GetSpaceDTO(item));
        }
        
        // POST api/spaces
        [HttpPost]
        public async Task<ActionResult<SpaceLightDTO>> PostAsync([FromBody] CreateSpaceDTO dto)
        {
            var item = await _spaces.CreateAsync(dto.OwnerId, dto.Name, dto.Slug, dto.Description, dto.Color);
            return Created($"api/spaces/{item.Id}", Mappers.GetSpaceLightDTO(item));
        }

        // PUT api/spaces/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SpaceLightDTO>> PutAsync(Guid id, [FromBody] UpdateSpaceDTO dto)
        {
            var item = await _spaces.UpdateAsync(id, dto.Name, dto.Slug, dto.Description, dto.Color);
            return Ok(Mappers.GetSpaceLightDTO(item));
        }

        // DELETE api/spaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _spaces.DeleteAsync(id);
            return Ok();
        }

        // PATCH api/spaces/5/owner
        [HttpPatch("{id}/owner")]
        public async Task<ActionResult<SpaceLightDTO>> ChangeOwnerAsync(Guid id, [FromBody] ChangeSpaceOwnerDTO dto)
        {
            var item = await _spaces.ChangeOwnerAsync(id, dto.OwnerId);
            return Ok(Mappers.GetSpaceLightDTO(item));
        }
    }
}
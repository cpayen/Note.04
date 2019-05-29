using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Note.Api.DTO;
using Note.Api.DTO.Page;
using Note.Core.Identity;
using Note.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Api.Controllers
{
    [Route("api/pages")]
    [ApiController]
    [Authorize]
    public class PagesController : ControllerBase
    {
        protected readonly Pages _pages;
        protected readonly ICurrentUserInfos _currentUserInfo;

        public PagesController(Pages pages, ICurrentUserInfos currentUserInfo)
        {
            _pages = pages;
            _currentUserInfo = currentUserInfo;
        }

        // GET api/pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageLightDTO>>> GetAsync()
        {
            var items = await _pages.GetAllAsync();
            return Ok(items.Select(o => Mappers.GetPageLightDTO(o)));
        }

        // GET api/pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PageDTO>> FindAsync(Guid id)
        {
            var item = await _pages.FindAsync(id);
            return Ok(Mappers.GetPageDTO(item));
        }

        // POST api/pages
        [HttpPost]
        public async Task<ActionResult<PageLightDTO>> PostAsync([FromBody] CreatePageDTO dto)
        {
            var item = await _pages.CreateAsync(dto.OwnerId, dto.Title, dto.Slug, dto.Description, dto.Content);
            return Created($"api/spaces/{item.Id}", Mappers.GetPageLightDTO(item));
        }

        // PUT api/pages/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PageLightDTO>> PutAsync(Guid id, [FromBody] UpdatePageDTO dto)
        {
            var item = await _pages.UpdateAsync(id, dto.Title, dto.Slug, dto.Description, dto.Content);
            return Ok(Mappers.GetPageLightDTO(item));
        }

        // DELETE api/pages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _pages.DeleteAsync(id);
            return Ok();
        }

        // PATCH api/pages/5/owner
        [HttpPatch("{id}/owner")]
        public async Task<ActionResult<PageLightDTO>> UpdateOwnerAsync(Guid id, [FromBody] ChangePageOwnerDTO dto)
        {
            var item = await _pages.ChangeOwnerAsync(id, dto.OwnerId);
            return Ok(Mappers.GetPageLightDTO(item));
        }

        // PATCH api/pages/5/content
        [HttpPatch("{id}/content")]
        public async Task<ActionResult<PageLightDTO>> UpdateContentAsync(Guid id, [FromBody] UpdatePageContentDTO dto)
        {
            var item = await _pages.UpdateContentAsync(id, dto.Content);
            return Ok(Mappers.GetPageLightDTO(item));
        }
    }
}
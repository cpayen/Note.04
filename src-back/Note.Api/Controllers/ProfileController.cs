using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Note.Api.DTO;
using Note.Api.DTO.AppUser;
using Note.Api.DTO.Profile;
using Note.Core.Services;
using System;
using System.Threading.Tasks;

namespace Note.Api.Controllers
{
    [Route("api/profile")]
    [ApiController]
    [Authorize(Policy = "ProfileOwner")]
    public class ProfileController : ControllerBase
    {
        protected readonly AppUsers _appUsers;

        public ProfileController(AppUsers appUsers)
        {
            _appUsers = appUsers;
        }

        // GET api/users/5
        [HttpGet("{id}/info")]
        public async Task<ActionResult<AppUserDTO>> GetAsync(Guid id)
        {
            var item = await _appUsers.FindAsync(id);
            return Ok(Mappers.GetAppUserDTO(item));
        }

        // PUT api/users/5
        [HttpPut("{id}/info")]
        public async Task<ActionResult<AppUserDTO>> PutAsync(Guid id, [FromBody] UpdateProfileInfoDTO dto)
        {
            var item = await _appUsers.UpdateAsync(id, dto.FirstName, dto.LastName, dto.Email);
            return Ok(Mappers.GetAppUserDTO(item));
        }

        // PUT api/users/5/change-password
        [HttpPut("{id}/change-password")]
        public async Task<ActionResult<AppUserDTO>> ChangePasswordAsync(Guid id, [FromBody] UpdateProfilePasswordDTO dto)
        {
            var item = await _appUsers.ChangePasswordAsync(id, dto.Password);
            return Ok(Mappers.GetAppUserDTO(item));
        }
    }
}
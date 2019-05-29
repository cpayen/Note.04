using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Note.Api.DTO;
using Note.Api.DTO.Login;
using Note.Core.Entities;
using Note.Core.Services;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Note.Api.Controllers
{
    //TODO: Add token expiration, token refresh...

    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        protected readonly AppUsers _appUsers;
        protected readonly IConfiguration _configuration;

        public AuthController(AppUsers appUsers, IConfiguration configuration)
        {
            _appUsers = appUsers;
            _configuration = configuration;
        }

        /// <summary>
        /// Try to log a user in.
        /// </summary>
        /// <param name="dto">LoginDTO with username and password.</param>
        /// <returns>An AuthenticatedUserDTO containing a token if authentication succeeded, unauthorized response otherwise.</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<AuthenticatedUserDTO>> LoginAsync([FromBody] LoginDTO dto)
        {
            var user = await _appUsers.LoginAsync(dto.UserName, dto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var loggedInUserDTO = new AuthenticatedUserDTO();
            loggedInUserDTO.User = Mappers.GetAppUserDTO(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in user.GetRoles())
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            if(!string.IsNullOrEmpty(user.FirstName))
            {
                claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            }

            if (!string.IsNullOrEmpty(user.LastName))
            {
                claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            }

            loggedInUserDTO.Token = BuildToken(claims);

            return Ok(loggedInUserDTO);
        }

        private string BuildToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                signingCredentials: creds,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
using Note.Api.DTO.AppUser;

namespace Note.Api.DTO.Login
{
    public class AuthenticatedUserDTO
    {
        public AppUserDTO User { get; set; }
        public string Token { get; set; }
    }
}

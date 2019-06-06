using Note.Api.DTO.AppUser;
using Note.Api.DTO.Page;
using Note.Api.DTO.Space;
using Note.Core.Entities;
using System.Collections.Generic;

namespace Note.Api.DTO
{
    public class Mappers
    {
        #region AppUser

        public static AppUserDTO GetAppUserDTO(Core.Entities.AppUser entity)
        {
            return new AppUserDTO
            {
                Id = entity.Id,
                UserName = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                FullName = entity.GetFullName(),
                Email = entity.Email,
                Roles = entity.GetRoles(),
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static AppUserLightDTO GetAppUserLightDTO(Core.Entities.AppUser entity)
        {
            return new AppUserLightDTO
            {
                Id = entity.Id,
                UserName = entity.UserName,
                FullName = entity.GetFullName(),
                Email = entity.Email
            };
        }

        #endregion
        
        #region Spaces

        public static SpaceLightDTO GetSpaceLightDTO(Core.Entities.Space entity)
        {
            return new SpaceLightDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                Owner = GetAppUserLightDTO(entity.Owner)
            };
        }

        public static SpaceDTO GetSpaceDTO(Core.Entities.Space entity)
        {
            var dto = new SpaceDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Slug = entity.Slug,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                Owner = GetAppUserLightDTO(entity.Owner),
            };

            dto.Pages = new List<PageLightDTO>();
            foreach (var page in entity.GetPages())
            {
                dto.Pages.Add(GetPageLightDTO(page));
            }

            return dto;
        }

        #endregion

        #region Pages

        public static PageLightDTO GetPageLightDTO(Core.Entities.Page entity)
        {
            return new PageLightDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                Owner = GetAppUserLightDTO(entity.Owner)
            };
        }

        public static PageDTO GetPageDTO(Core.Entities.Page entity)
        {
            var dto = new PageDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Slug = entity.Slug,
                Description = entity.Description,
                Content = entity.Content,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                Owner = GetAppUserLightDTO(entity.Owner),
                Space = GetSpaceLightDTO(entity.Space),
            };

            return dto;
        }

        #endregion
    }
}

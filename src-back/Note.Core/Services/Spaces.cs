using Note.Core.Data;
using Note.Core.Entities;
using Note.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Note.Core.Services
{
    public class Spaces
    {
        protected readonly IEntityFactory _factory;

        public Spaces(IEntityFactory factory)
        {
            _factory = factory;
        }

        public async Task<Space> FindAsync(Guid id)
        {
            var space = await _factory.GetRepository<Space>().FindAsync(id, "Pages", "Owner");
            return space;
        }

        public async Task<IEnumerable<Space>> GetAllAsync()
        {
            var spaces = await _factory.GetRepository<Space>().GetAllAsync("Pages", "Owner");
            return spaces;
        }

        public async Task<IEnumerable<Space>> FindByOwnerAsync(Guid ownerId)
        {
            var spaces = await _factory.GetRepository<Space>().FindByAsync(o => o.Owner.Id == ownerId);
            return spaces;
        }

        public async Task<Space> CreateAsync(Guid ownerId, string name, string slug, string description, string color)
        {
            var owner = 
                await _factory.GetRepository<AppUser>().FindAsync(ownerId) ?? 
                throw new NotFoundException($"AppUser [{ownerId}] entity not found.");

            var entity = new Space
            {
                Name = name,
                Slug = slug,
                Description = description,
                Color = color,
                Owner = owner
            };

            _factory.GetRepository<Space>().Create(entity);
            await _factory.SaveAsync();

            return entity;
        }

        public async Task<Space> UpdateAsync(Guid id, string name, string slug, string description, string color)
        {
            var entity = 
                await _factory.GetRepository<Space>().FindAsync(id) ?? 
                throw new NotFoundException($"Space [{id}] entity not found.");

            entity.Name = name;
            entity.Slug = slug;
            entity.Description = description;
            entity.Color = color;

            _factory.GetRepository<Space>().Update(entity);
            await _factory.SaveAsync();

            return entity;
        }

        public async Task<Space> ChangeOwnerAsync(Guid id, Guid ownerId)
        {
            var entity = 
                await _factory.GetRepository<Space>().FindAsync(id) ?? 
                throw new NotFoundException($"Space [{id}] entity not found.");

            var owner = 
                await _factory.GetRepository<AppUser>().FindAsync(ownerId) ?? 
                throw new NotFoundException($"AppUser [{ownerId}] entity not found.");

            entity.Owner = owner;

            _factory.GetRepository<Space>().Update(entity);
            await _factory.SaveAsync();

            return entity;
        }

        public async Task<Space> DeleteAsync(Guid id)
        {
            var entity = await _factory.GetRepository<Space>().FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException($"Space [{id}] entity not found.");
            }

            _factory.GetRepository<Space>().Delete(entity);
            await _factory.SaveAsync();

            return entity;
        }
    }
}

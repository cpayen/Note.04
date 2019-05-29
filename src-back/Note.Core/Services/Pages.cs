using Note.Core.Data;
using Note.Core.Entities;
using Note.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Note.Core.Services
{
    public class Pages
    {
        protected readonly IEntityFactory _factory;

        public Pages(IEntityFactory factory)
        {
            _factory = factory;
        }

        public async Task<Page> FindAsync(Guid id)
        {
            var page = await _factory.GetRepository<Page>().FindAsync(id, "Space", "Owner");
            return page;
        }

        public async Task<IEnumerable<Page>> GetAllAsync()
        {
            var pages = await _factory.GetRepository<Page>().GetAllAsync();
            return pages;
        }

        public async Task<IEnumerable<Page>> FindBySpaceAsync(Guid spaceId)
        {
            var pages = await _factory.GetRepository<Page>().FindByAsync(o => o.Space.Id == spaceId);
            return pages;
        }

        public async Task<Page> CreateAsync(Guid ownerId, string title, string slug, string description, string content)
        {
            var owner =
                await _factory.GetRepository<AppUser>().FindAsync(ownerId) ??
                throw new NotFoundException($"AppUser [{ownerId}] entity not found.");

            var entity = new Page
            {
                Title = title,
                Slug = slug,
                Description = description,
                Content = content,
                Owner = owner
            };

            _factory.GetRepository<Page>().Create(entity);
            await _factory.SaveAsync();

            return entity;
        }

        public async Task<Page> UpdateAsync(Guid id, string title, string slug, string description, string content)
        {
            var entity =
                await _factory.GetRepository<Page>().FindAsync(id) ??
                throw new NotFoundException($"Page [{id}] entity not found.");

            entity.Title = title;
            entity.Slug = slug;
            entity.Description = description;
            entity.Content = content;

            _factory.GetRepository<Page>().Update(entity);
            await _factory.SaveAsync();

            return entity;
        }

        public async Task<Page> ChangeOwnerAsync(Guid id, Guid ownerId)
        {
            var entity =
                await _factory.GetRepository<Page>().FindAsync(id) ??
                throw new NotFoundException($"Page [{id}] entity not found.");

            var owner =
                await _factory.GetRepository<AppUser>().FindAsync(ownerId) ??
                throw new NotFoundException($"AppUser [{ownerId}] entity not found.");

            entity.Owner = owner;

            _factory.GetRepository<Page>().Update(entity);
            await _factory.SaveAsync();

            return entity;
        }

        public async Task<Page> UpdateContentAsync(Guid id, string content)
        {
            var entity =
                await _factory.GetRepository<Page>().FindAsync(id) ??
                throw new NotFoundException($"Page [{id}] entity not found.");

            entity.Content = content;

            _factory.GetRepository<Page>().Update(entity);
            await _factory.SaveAsync();

            return entity;
        }

        public async Task<Page> DeleteAsync(Guid id)
        {
            var entity = await _factory.GetRepository<Page>().FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException($"Page [{id}] entity not found.");
            }

            _factory.GetRepository<Page>().Delete(entity);
            await _factory.SaveAsync();

            return entity;
        }
    }
}

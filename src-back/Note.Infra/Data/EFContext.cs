﻿using Microsoft.EntityFrameworkCore;
using Note.Core.Entities;
using Note.Core.Entities.Base;
using Note.Core.Identity;
using Note.Infra.Data.InitialData;
using Note.Infra.Data.Specs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Note.Infra.Data
{
    public class EFContext : DbContext
    {
        protected readonly ICurrentUserInfos _currentUserInfos;

        public EFContext(DbContextOptions<EFContext> options, ICurrentUserInfos currentUserInfos) : base(options)
        {
            _currentUserInfos = currentUserInfos;
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specs
            new AppUserSpec(modelBuilder.Entity<AppUser>());
            new SpaceSpec(modelBuilder.Entity<Space>());
            new PageSpec(modelBuilder.Entity<Page>());

            // Seed admin user
            Seed.AdminAppUser(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    var user = _currentUserInfos.UserName;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedAt = now;
                            trackable.UpdatedBy = user;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.CreatedBy = user;
                            break;
                    }
                }
            }
        }
    }
}

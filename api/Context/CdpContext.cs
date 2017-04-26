using System;
using System.Linq;
using System.Reflection;
using domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Context
{
    public class CdpContext : DbContext
    {
        private readonly IHttpContextAccessor _context;
        public CdpContext(DbContextOptions options, IHttpContextAccessor context) : base(options)
        {
            _context = context;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Arena> Arena { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureArena(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("user");
                b.HasKey(u => u.Id);
                b.Property(u => u.Id).HasColumnName("id");
                b.Property(u => u.FirstName).IsRequired().HasMaxLength(100).HasColumnName("firstName");
                b.Property(u => u.LastName).HasMaxLength(100).HasColumnName("lastName");
                b.Property(u => u.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
                b.Property(u => u.Password).IsRequired().HasMaxLength(100).HasColumnName("password");
                b.Property(u => u.Nickname).HasMaxLength(100).HasColumnName("nickname");
                b.Property(u => u.Number).HasColumnName("number");
                b.Property(u => u.Position).HasMaxLength(100).HasColumnName("position");
                b.Property(u => u.CreatedAt).IsRequired().HasColumnName("createdAt");
            });
        }

        private static void ConfigureArena(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arena>(b =>
            {
                b.ToTable("arena");
                b.HasKey(a => a.Id);
                b.Property(a => a.Id).HasColumnName("id");
                b.Property(a => a.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
                b.Property(a => a.Description).IsRequired().HasMaxLength(100).HasColumnName("description");
                b.Property(a => a.Latitude).HasMaxLength(30).HasColumnName("latitude");
                b.Property(a => a.Longitude).HasMaxLength(30).HasColumnName("longitude");
                b.Property(u => u.CreatedAt).IsRequired().HasColumnName("createdAt");
            });
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry<BaseEntity> entry in modifiedEntries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;

                    var createdByUserId = entry.Entity.GetType().GetRuntimeProperties().FirstOrDefault(w => w.Name.Equals("CreatedByUserId"));
                    if (createdByUserId != null && _context.HttpContext != null)
                    {
                        var userId = Convert.ToInt32(_context.HttpContext.User.Claims.First(w => w.Type.Equals("id")).Value);
                        createdByUserId.SetValue(entry.Entity, userId);
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
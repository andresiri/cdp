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
        private readonly IHttpContextAccessor _httpContext;
        public CdpContext(DbContextOptions options, IHttpContextAccessor httpContext) : base(options)
        {
            _httpContext = httpContext;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Arena> Arena { get; set; }
        public DbSet<Pelada> Pelada { get; set; }
        public DbSet<PeladaUser> PeladaUser { get; set; }
        public DbSet<PeladaEvent> PeladaEvent { get; set; }
        public DbSet<PeladaEventUser> PeladaEventUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureArena(modelBuilder);
            ConfigurePelada(modelBuilder);
            ConfigurePeladaUser(modelBuilder);
            ConfigurePeladaTeam(modelBuilder);
            ConfigurePeladaEvent(modelBuilder);
            ConfigurePeladaEventUser(modelBuilder);

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
                b.Property(u => u.Position).HasColumnName("position");
                b.Property(u => u.Birthday).HasColumnName("birthday");
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

        private static void ConfigurePelada(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelada>(b =>
            {
                b.ToTable("pelada");
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.Name).HasColumnName("name").HasMaxLength(50);
                b.Property(p => p.ArenaDefaultId).HasColumnName("arenaDefaultId");
                b.Property(p => p.Day).IsRequired().HasColumnName("day");
                b.Property(p => p.CreatedByUserId).HasColumnName("createdByUserId");
                b.Property(p => p.CreatedAt).IsRequired().HasColumnName("createdAt");
                b.HasOne(p => p.ArenaDefault).WithMany(p => p.Peladas).OnDelete(DeleteBehavior.Restrict).HasForeignKey(p => p.ArenaDefaultId).HasConstraintName("ForeignKey_Pelada_ArenaDefaultId");
                b.HasOne(p => p.CreatedByUser).WithMany(p => p.Peladas).OnDelete(DeleteBehavior.Restrict).HasForeignKey(p => p.CreatedByUserId).HasConstraintName("ForeignKey_Pelada_UserId");
            });
        }

        private static void ConfigurePeladaTeam(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeladaTeam>(b =>
            {
                b.ToTable("peladaTeam");
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.Name).IsRequired().HasColumnName("name").HasMaxLength(50);
                b.Property(p => p.PeladaId).IsRequired().HasColumnName("peladaId");               
                b.Property(p => p.CreatedAt).IsRequired().HasColumnName("createdAt");  
                b.HasOne(p => p.Pelada).WithMany(p => p.PeladaTeams).HasForeignKey(p => p.PeladaId).HasConstraintName("ForeignKey_PeladaTeam_PeladaId");
            });
        }
        
        private static void ConfigurePeladaUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeladaUser>(b =>
            {
                b.ToTable("peladaUser");
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.PeladaId).IsRequired().HasColumnName("peladaId");
                b.Property(p => p.UserId).IsRequired().HasColumnName("userId");
                b.Property(p => p.CreatedAt).IsRequired().HasColumnName("createdAt");
                b.Property(p => p.IsMonthly).IsRequired().HasDefaultValue(false).HasColumnName("isMonthly");
                b.Property(p => p.IsAdministrator).IsRequired().HasDefaultValue(false).HasColumnName("isAdministrator");
                b.HasAlternateKey(a => new { a.PeladaId, a.UserId });
                b.HasOne(p => p.User).WithMany(p => p.PeladaUsers).HasForeignKey(p => p.UserId).HasConstraintName("ForeignKey_PeladaUser_UserId");
                b.HasOne(p => p.Pelada).WithMany(p => p.PeladaUsers).HasForeignKey(p => p.PeladaId).HasConstraintName("ForeignKey_PeladaUser_PeladaId");
            });
        }

        private static void ConfigurePeladaEvent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeladaEvent>(b =>
            {
                b.ToTable("peladaEvent");
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.PeladaId).IsRequired().HasColumnName("peladaId");
                b.Property(p => p.Date).IsRequired().HasColumnName("date");
                b.Property(p => p.QuantityOfUsers).IsRequired().HasColumnName("quantityOfUsers");
                b.Property(p => p.ArenaId).IsRequired().HasColumnName("arenaId");
                b.Property(p => p.CreatedAt).IsRequired().HasColumnName("createdAt");
                b.HasOne(p => p.Pelada).WithMany(p => p.PeladaEvents).HasForeignKey(p => p.PeladaId).HasConstraintName("ForeignKey_PeladaEvent_PeladaId");
                b.HasOne(p => p.Arena).WithMany(p => p.PeladaEvents).HasForeignKey(p => p.ArenaId).HasConstraintName("ForeignKey_PeladaEvent_ArenaId");
            });
        }

        private static void ConfigurePeladaEventUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeladaEventUser>(b =>
            {
                b.ToTable("peladaEventUser");
                b.HasKey(p => p.Id);
                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.PeladaEventId).IsRequired().HasColumnName("peladaEventId");
                b.Property(p => p.UserId).IsRequired().HasColumnName("userId");
                b.Property(p => p.UserConfirmed).HasDefaultValue(false).HasColumnName("userConfirmed");
                b.Property(p => p.CreatedAt).IsRequired().HasColumnName("createdAt");
                b.HasOne(p => p.PeladaEvent).WithMany(p => p.PeladaEventUsers).HasForeignKey(p => p.PeladaEventId).HasConstraintName("ForeignKey_PeladaEventUser_PeladaEventoId");
                b.HasOne(p => p.User).WithMany(p => p.PeladaEventUsers).HasForeignKey(p => p.UserId).HasConstraintName("ForeignKey_PeladaEventUser_UserId");
            });
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries<EntityModel>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry<EntityModel> entry in modifiedEntries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;

                    var createdByUserId = entry.Entity.GetType().GetRuntimeProperties().FirstOrDefault(w => w.Name.Equals("CreatedByUserId"));
                    if (createdByUserId != null && _httpContext.HttpContext != null)
                    {
                        var userId = Convert.ToInt32(_httpContext.HttpContext.User.Claims.First(w => w.Type.Equals("userId")).Value);
                        createdByUserId.SetValue(entry.Entity, userId);
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
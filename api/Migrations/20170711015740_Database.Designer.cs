using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using api.Context;

namespace api.Migrations
{
    [DbContext(typeof(CdpContext))]
    [Migration("20170711015740_Database")]
    partial class Database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("domain.Entities.Arena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasMaxLength(100);

                    b.Property<string>("Latitude")
                        .HasColumnName("latitude")
                        .HasMaxLength(30);

                    b.Property<string>("Longitude")
                        .HasColumnName("longitude")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("arena");
                });

            modelBuilder.Entity("domain.Entities.Pelada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("ArenaDefaultId")
                        .HasColumnName("arenaDefaultId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnName("createdByUserId");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnName("day");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ArenaDefaultId");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("pelada");
                });

            modelBuilder.Entity("domain.Entities.PeladaEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ArenaId")
                        .HasColumnName("arenaId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<int>("PeladaId")
                        .HasColumnName("peladaId");

                    b.Property<int>("QuantityOfUsers")
                        .HasColumnName("quantityOfUsers");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.HasIndex("PeladaId");

                    b.ToTable("peladaEvent");
                });

            modelBuilder.Entity("domain.Entities.PeladaEventUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<int>("PeladaEventId")
                        .HasColumnName("peladaEventId");

                    b.Property<bool>("UserConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userConfirmed")
                        .HasDefaultValue(false);

                    b.Property<int>("UserId")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("PeladaEventId");

                    b.HasIndex("UserId");

                    b.ToTable("peladaEventUser");
                });

            modelBuilder.Entity("domain.Entities.PeladaTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<int>("PeladaId")
                        .HasColumnName("peladaId");

                    b.HasKey("Id");

                    b.HasIndex("PeladaId");

                    b.ToTable("peladaTeam");
                });

            modelBuilder.Entity("domain.Entities.PeladaUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<bool>("IsAdministrator")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("isAdministrator")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsMonthly")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("isMonthly")
                        .HasDefaultValue(false);

                    b.Property<int>("PeladaId")
                        .HasColumnName("peladaId");

                    b.Property<int>("UserId")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasAlternateKey("PeladaId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("peladaUser");
                });

            modelBuilder.Entity("domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("firstName")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasColumnName("lastName")
                        .HasMaxLength(100);

                    b.Property<string>("Nickname")
                        .HasColumnName("nickname")
                        .HasMaxLength(100);

                    b.Property<byte?>("Number")
                        .HasColumnName("number");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(100);

                    b.Property<string>("Position")
                        .HasColumnName("position");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("domain.Entities.Pelada", b =>
                {
                    b.HasOne("domain.Entities.Arena", "ArenaDefault")
                        .WithMany("Peladas")
                        .HasForeignKey("ArenaDefaultId")
                        .HasConstraintName("ForeignKey_Pelada_ArenaDefaultId");

                    b.HasOne("domain.Entities.User", "CreatedByUser")
                        .WithMany("Peladas")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("ForeignKey_Pelada_UserId");
                });

            modelBuilder.Entity("domain.Entities.PeladaEvent", b =>
                {
                    b.HasOne("domain.Entities.Arena", "Arena")
                        .WithMany("PeladaEvents")
                        .HasForeignKey("ArenaId")
                        .HasConstraintName("ForeignKey_PeladaEvent_ArenaId");

                    b.HasOne("domain.Entities.Pelada", "Pelada")
                        .WithMany("PeladaEvents")
                        .HasForeignKey("PeladaId")
                        .HasConstraintName("ForeignKey_PeladaEvent_PeladaId");
                });

            modelBuilder.Entity("domain.Entities.PeladaEventUser", b =>
                {
                    b.HasOne("domain.Entities.PeladaEvent", "PeladaEvent")
                        .WithMany("PeladaEventUsers")
                        .HasForeignKey("PeladaEventId")
                        .HasConstraintName("ForeignKey_PeladaEventUser_PeladaEventoId");

                    b.HasOne("domain.Entities.User", "User")
                        .WithMany("PeladaEventUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("ForeignKey_PeladaEventUser_UserId");
                });

            modelBuilder.Entity("domain.Entities.PeladaTeam", b =>
                {
                    b.HasOne("domain.Entities.Pelada", "Pelada")
                        .WithMany("PeladaTeams")
                        .HasForeignKey("PeladaId")
                        .HasConstraintName("ForeignKey_PeladaTeam_PeladaId");
                });

            modelBuilder.Entity("domain.Entities.PeladaUser", b =>
                {
                    b.HasOne("domain.Entities.Pelada", "Pelada")
                        .WithMany("PeladaUsers")
                        .HasForeignKey("PeladaId")
                        .HasConstraintName("ForeignKey_PeladaUser_PeladaId");

                    b.HasOne("domain.Entities.User", "User")
                        .WithMany("PeladaUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("ForeignKey_PeladaUser_UserId");
                });
        }
    }
}

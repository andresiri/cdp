using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using api.Context;

namespace api.Migrations
{
    [DbContext(typeof(CdpContext))]
    partial class CdpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnName("createdByUserId");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("pelada");
                });

            modelBuilder.Entity("domain.Entities.PeladaUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("createdAt");

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
                    b.HasOne("domain.Entities.User", "CreatedByUser")
                        .WithMany("Peladas")
                        .HasForeignKey("CreatedByUserId")
                        .HasConstraintName("ForeignKey_Pelada_UserId");
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

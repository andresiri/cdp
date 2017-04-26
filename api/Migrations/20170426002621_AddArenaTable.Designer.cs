using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using api.Context;

namespace api.Migrations
{
    [DbContext(typeof(CdpContext))]
    [Migration("20170426002621_AddArenaTable")]
    partial class AddArenaTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("Position")
                        .HasColumnName("position")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("user");
                });
        }
    }
}

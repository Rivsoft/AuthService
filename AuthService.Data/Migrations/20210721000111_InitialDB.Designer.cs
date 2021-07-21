﻿// <auto-generated />
using System;
using AuthService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthService.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210721000111_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthService.Data.Entities.SessionToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SessionTokens");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5abd2f27-4446-4e88-b6b8-9efe1ca8d59a"),
                            CreatedAt = new DateTime(2021, 7, 21, 0, 1, 11, 338, DateTimeKind.Utc).AddTicks(9046),
                            ExpiresAt = new DateTime(2021, 7, 28, 0, 1, 11, 338, DateTimeKind.Utc).AddTicks(9312),
                            UserId = new Guid("85f48c01-f48a-4841-aff5-00b5e25950d1")
                        });
                });

            modelBuilder.Entity("AuthService.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("85f48c01-f48a-4841-aff5-00b5e25950d1"),
                            UserName = "user1"
                        });
                });

            modelBuilder.Entity("AuthService.Data.Entities.SessionToken", b =>
                {
                    b.HasOne("AuthService.Data.Entities.User", "User")
                        .WithMany("SessionTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthService.Data.Entities.User", b =>
                {
                    b.Navigation("SessionTokens");
                });
#pragma warning restore 612, 618
        }
    }
}

using AuthService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AuthService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SessionToken> SessionTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("{85F48C01-F48A-4841-AFF5-00B5E25950D1}"),
                    UserName = "user1"
                }
            );

            modelBuilder.Entity<SessionToken>().HasData(
                new SessionToken()
                {
                    Id = new Guid("{5ABD2F27-4446-4E88-B6B8-9EFE1CA8D59A}"),
                    UserId = new Guid("{85F48C01-F48A-4841-AFF5-00B5E25950D1}"),
                    CreatedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddDays(7)
                }
            );
        }
    }
}

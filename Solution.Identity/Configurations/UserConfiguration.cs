using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure (EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "14dc39fa-f6df-4fdf-ad6f-0cbb4790f475",
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@localhost",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "admin")
                },
                new ApplicationUser
                {
                    Id = "19f5b9a1-8f06-44b6-a959-800ffb9cdda9",
                    FirstName = "User",
                    LastName = "User",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@localhost",
                    NormalizedEmail = "USER@LOCALHOST",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "user")
                },
                new ApplicationUser
                {
                    Id = "15178df5-34d2-4f45-b192-ebf3871242d4",
                    FirstName = "User2",
                    LastName = "User2",
                    UserName = "user2",
                    NormalizedUserName = "USER2",
                    Email = "user2@localhost",
                    NormalizedEmail = "USER2@LOCALHOST",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "user2")
                }
            );
        }
    }
}

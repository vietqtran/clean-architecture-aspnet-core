using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solution.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure (EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "80f623b2-baba-43a4-bfa1-e8a5b63cb5ca",
                    UserId = "14dc39fa-f6df-4fdf-ad6f-0cbb4790f475"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "44bb0f62-62df-43a5-a7c3-0c7e92ff4239",
                    UserId = "19f5b9a1-8f06-44b6-a959-800ffb9cdda9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "44bb0f62-62df-43a5-a7c3-0c7e92ff4239",
                    UserId = "15178df5-34d2-4f45-b192-ebf3871242d4"
                }
            );
        }
    }
}

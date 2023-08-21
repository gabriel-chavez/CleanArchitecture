using CleanAchitecture.Identity.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "63c5d7f4-b3bd-45ce-a60a-d2b5db5aaa90", //https://guidgenerator.com/online-guid-generator.aspx
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Gabriel",
                    Apellidos = "Chavez",
                    UserName = "lchavez",
                    NormalizedUserName = "lchavez",
                    PasswordHash = hasher.HashPassword(null, "Gabriel123"),
                    EmailConfirmed = true,
                },
                 new ApplicationUser
                 {
                     Id = "c7f1d347-05ce-4ec4-9f4f-3ce8f84864fd", //https://guidgenerator.com/online-guid-generator.aspx
                     Email = "JuanRodriguez@localhost.com",
                     NormalizedEmail = "JuanRodriguez@localhost.com",
                     Nombre = "Juan",
                     Apellidos = "Rodriguez",
                     UserName = "jRodriguez",
                     NormalizedUserName = "jRodriguez",
                     PasswordHash = hasher.HashPassword(null, "Gabriel123"),
                     EmailConfirmed = true,
                 }
                );
        }
    }
}

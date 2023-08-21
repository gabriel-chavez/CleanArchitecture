using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanAchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "ce96366a-1fd5-4396-800c-cd450b76d3f2",
                    UserId = "63c5d7f4-b3bd-45ce-a60a-d2b5db5aaa90"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "34146b5e-171c-4a08-9b7c-203c264738c0",
                    UserId = "c7f1d347-05ce-4ec4-9f4f-3ce8f84864fd"
                });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savr.Core.Domain.Models;

namespace Savr.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "savr");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.IsActive).HasDefaultValue(false);
        }
    }
}

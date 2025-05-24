using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savr.Core.Domain.Models;

namespace Savr.Infrastructure.Persistence.Configurations
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.ToTable("Goals", "savr");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.GoalId).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
            builder.Property(c => c.SavedAmount).HasColumnName("SavedAmount").HasColumnType("money");
            builder.Property(c => c.TargetAmount).HasColumnName("TargetAmount").HasColumnType("money");
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        }
    }
}

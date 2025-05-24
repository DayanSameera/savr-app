using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savr.Core.Domain.Models;

namespace Savr.Infrastructure.Persistence.Configurations
{
    internal class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes", "savr");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.IncomeId).HasDefaultValue("NEWID()").ValueGeneratedOnAdd();
            builder.Property(c => c.Amount).HasColumnName("Amount").HasColumnType("money");
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        }
    }
}

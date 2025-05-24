using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savr.Core.Domain.Models;

namespace Savr.Infrastructure.Persistence.Configurations
{
    internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expense", "savr");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.ExpenseId).HasDefaultValue("NEWID()").ValueGeneratedOnAdd();
            builder.Property(c => c.Amount).HasColumnName("Amount").HasColumnType("money");
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        }
    }
}

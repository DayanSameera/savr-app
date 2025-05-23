using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savr.Core.Domain.Models;

namespace Savr.Infrastructure.Persistence.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<FinancialTransaction>
    {
        public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
        {
            builder.ToTable("FinancialTransactions", "savr");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.TransactionId).HasDefaultValue("NEWID()").ValueGeneratedOnAdd();
            builder.Property(c => c.Amount).HasColumnName("Amount").HasColumnType("money");
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        }
    }
}

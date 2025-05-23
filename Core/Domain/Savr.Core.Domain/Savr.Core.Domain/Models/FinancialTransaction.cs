using Savr.Core.Domain.Enums;

namespace Savr.Core.Domain.Models
{
    public class FinancialTransaction : ModelBase
    {
        public Guid TransactionId { get; set; }
        public required string Name { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public CategoryEnum Category { get; set; }
        public required decimal Amount { get; set; }
        public string? Notes { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}

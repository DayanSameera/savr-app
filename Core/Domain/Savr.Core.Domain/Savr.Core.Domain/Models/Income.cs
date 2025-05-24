using Savr.Core.Domain.Enums;

namespace Savr.Core.Domain.Models
{
    public class Income : ModelBase
    {
        public required string IncomeId { get; set; }
        public required string SourceName { get; set; }
        public IncomeCategoryEnum IncomeCategory { get; set; }
        public required decimal Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}

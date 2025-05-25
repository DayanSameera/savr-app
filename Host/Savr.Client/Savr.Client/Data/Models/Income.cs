using Savr.Client.Data.Enum;

namespace Savr.Client.Data.Models
{
    public class Income
    {
        public required string IncomeId { get; set; }
        public required string SourceName { get; set; }
        public IncomeCategoryEnum IncomeCategory { get; set; }
        public required decimal Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
    }
}

using Savr.Core.Domain.Enums;

namespace Savr.Core.Domain.Models
{
    public class Expense : ModelBase
    {
        public required string ExpenseId { get; set; }
        public required string Reference { get; set; }
        public ExpenseCategoryEnum ExpenseType { get; set; }
        public required decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}

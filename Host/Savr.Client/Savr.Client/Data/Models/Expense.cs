using Savr.Client.Data.Enum;

namespace Savr.Client.Data.Models
{
    public class Expense
    {
        public required string ExpenseId { get; set; }
        public required string Reference { get; set; }
        public ExpenseCategoryEnum ExpenseType { get; set; }
        public required decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

using Savr.Client.Data.Enum;

namespace Savr.Client.Data.Models
{
    public class Expense
    {
        public required string Reference { get; set; }
        public required string ExpenseType { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
    }
}

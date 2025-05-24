namespace Savr.Core.Application.Expenses.Queries.GetAll
{
    public class ExpenseDTO
    {
        public  string ExpenseId { get; set; }
        public  string Reference { get; set; }
        public string ExpenseType { get; set; }
        public  decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

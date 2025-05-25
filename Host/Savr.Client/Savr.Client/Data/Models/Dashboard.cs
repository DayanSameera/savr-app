namespace Savr.Client.Data.Models
{
    public class Dashboard
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpences { get; set; }
        public decimal TotalSavings { get; set; }
        public List<GraphValues>? IncomeItems { get; set; }
        public List<GraphValues>? ExpenseItems { get; set; }
    }

    public class GraphValues
    {
        public string Category { get; set; }
        public decimal Sum { get; set; }
    }
}

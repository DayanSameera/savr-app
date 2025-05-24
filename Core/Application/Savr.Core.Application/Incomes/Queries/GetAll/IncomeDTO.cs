namespace Savr.Core.Application.Incomes.Queries.GetAll
{
    public class IncomeDTO
    {
        public  string IncomeId { get; set; }
        public  string SourceName { get; set; }
        public string IncomeCategory { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
    }
}

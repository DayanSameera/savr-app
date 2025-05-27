using Savr.Client.Data.Models;

namespace Savr.Client.Services.Interafces
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> GetExpense(string Id);
        Task<string> CreateExpense(Expense expense);
        Task<bool> DeleteExpense(string Id);
    }
}

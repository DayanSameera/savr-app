using Savr.Client.Data.Models;
using Savr.Client.Services.Interafces;

namespace Savr.Client.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient httpClient;

        public ExpenseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> CreateExpense(Expense expense)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Expense", expense);
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> DeleteExpense(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpense(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            return await httpClient.GetFromJsonAsync<Expense[]>("api/Expense");
        }
    }
}

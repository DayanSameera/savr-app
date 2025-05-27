using Savr.Client.Data.Models;
using Savr.Client.Services.Interafces;
using static System.Net.WebRequestMethods;

namespace Savr.Client.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly HttpClient httpClient;

        public IncomeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> CreateIncome(Income income)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Income", income);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> DeleteIncome(string id)
        {
            var response = await httpClient.PostAsJsonAsync("/api/Income/delete/" + id, id);
            return true;
        }

        public Task<Income> GetIncome(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Income>> GetIncomes()
        {
            return await httpClient.GetFromJsonAsync<Income[]>("api/Income");
        }
    }
}

using Savr.Client.Data.Models;
using Savr.Client.Services.Interafces;

namespace Savr.Client.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient httpClient;

        public DashboardService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Dashboard> GetDashboardData()
        {
            return await httpClient.GetFromJsonAsync<Dashboard>("api/Dashboard");
        }
    }
}

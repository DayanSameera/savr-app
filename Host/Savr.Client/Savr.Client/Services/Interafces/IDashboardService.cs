using Savr.Client.Data.Models;

namespace Savr.Client.Services.Interafces
{
    public interface IDashboardService
    {
        Task<Dashboard> GetDashboardData();
    }
}

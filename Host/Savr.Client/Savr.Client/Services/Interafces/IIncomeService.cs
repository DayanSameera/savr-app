
using Savr.Client.Data.Models;

namespace Savr.Client.Services.Interafces
{
    public interface IIncomeService
    {
        Task<IEnumerable<Income>> GetIncomes();
        Task<Income> GetIncome(string Id);
        Task<string> CreateIncome(Income income);
        Task<string> DeleteIncome(string Id);
    }
}

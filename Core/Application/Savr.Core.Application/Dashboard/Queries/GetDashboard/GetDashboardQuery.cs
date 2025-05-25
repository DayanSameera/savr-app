using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Savr.Core.Application.Common.Interfaces;
using Savr.Core.Application.Expenses.Queries.GetAll;

namespace Savr.Core.Application.Dashboard.Queries.GetDashboard
{
    public class GetDashboardQuery : IRequest<DashboardDTO>
    {
    }

    public class GetGashboardQueryHandler : IRequestHandler<GetDashboardQuery, DashboardDTO>
    {
        private readonly IApplicationDbContext _context;

        public GetGashboardQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDTO> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            var dashboardDTO = new DashboardDTO();

            var incomeList = await _context.Incomes.Where(q => !q.IsDeleted).ToListAsync();
            var expenseList = await _context.Expenses.Where(q => !q.IsDeleted).ToListAsync();
            var tIncome = incomeList.Select(q => q.Amount).Sum();
            var tExpense = expenseList.Select(q => q.Amount).Sum();
            var tSavings = tIncome - tExpense;

            var incomeItems = incomeList.GroupBy(x => x.IncomeCategory, x => x.Amount)
                  .Select(g => new GraphValues { Category = g.Key.ToString(), Sum = decimal.Round(g.Sum(), 2, MidpointRounding.AwayFromZero) });

            var expensesItems = expenseList.GroupBy(x => x.ExpenseType, x => x.Amount)
                 .Select(g => new GraphValues { Category = g.Key.ToString(), Sum = decimal.Round(g.Sum(), 2, MidpointRounding.AwayFromZero) });

            dashboardDTO.TotalIncome = decimal.Round(tIncome, 2, MidpointRounding.AwayFromZero);
            dashboardDTO.TotalExpences = decimal.Round(tExpense, 2, MidpointRounding.AwayFromZero);
            dashboardDTO.TotalSavings = decimal.Round(tSavings, 2, MidpointRounding.AwayFromZero);
            dashboardDTO.IncomeItems = incomeItems?.ToList();
            dashboardDTO.ExpenseItems = expensesItems?.ToList();

            return dashboardDTO;
        }
    }
}

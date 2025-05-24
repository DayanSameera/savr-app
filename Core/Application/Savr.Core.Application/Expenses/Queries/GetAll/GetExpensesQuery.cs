using MediatR;
using Microsoft.EntityFrameworkCore;
using Savr.Core.Application.Common.Interfaces;

namespace Savr.Core.Application.Expenses.Queries.GetAll
{
    public class GetExpensesQuery : IRequest<List<ExpenseDTO>>
    {
    }

    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, List<ExpenseDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetExpensesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpenseDTO>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Expenses.Where(q => !q.IsDeleted).Select(x => new ExpenseDTO
            {
                Amount = x.Amount,
                Date = x.Date,
                ExpenseId = x.ExpenseId,
                ExpenseType = x.ExpenseType.ToString(),
                Reference = x.Reference,
            }).ToListAsync();
        }
    }
}

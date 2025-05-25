using MediatR;
using Microsoft.EntityFrameworkCore;
using Savr.Core.Application.Common.Interfaces;

namespace Savr.Core.Application.Incomes.Queries.GetAll
{
    public class GetIncomesQuery : IRequest<List<IncomeDTO>>
    {
    }

    public class GetIncomesQueryHandler : IRequestHandler<GetIncomesQuery, List<IncomeDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetIncomesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<IncomeDTO>> Handle(GetIncomesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Incomes.Where(q => !q.IsDeleted).Select(x => new IncomeDTO
            {
                Amount = x.Amount,
                Date = x.Date,
                IncomeId = x.IncomeId,
                IncomeCategory = x.IncomeCategory.ToString(),
                Note = x.Note,
                SourceName = x.SourceName
            }).ToListAsync();
        }
    }
}

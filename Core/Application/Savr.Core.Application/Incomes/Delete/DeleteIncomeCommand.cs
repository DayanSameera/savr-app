using MediatR;
using Microsoft.EntityFrameworkCore;
using Savr.Core.Application.Common.Interfaces;

namespace Savr.Core.Application.Incomes.Delete
{
    public class DeleteIncomeCommand : IRequest<bool>
    {
        public required string Reference { get; set; }
    }

    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteIncomeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteIncomeCommand command, CancellationToken cancellationToken)
        {
            var expenseItem = await _context.Incomes
                  .Where(q => !q.IsDeleted && command.Reference == q.IncomeId).FirstOrDefaultAsync();

            if (expenseItem == null)
            {
                return false;
            }

            expenseItem.IsDeleted = true;

            _context.Incomes.Update(expenseItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

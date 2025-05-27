using MediatR;
using Microsoft.EntityFrameworkCore;
using Savr.Core.Application.Common.Interfaces;

namespace Savr.Core.Application.Expenses.Commands.Delete
{
    public class DeleteExpenseCommand : IRequest<bool>
    {
        public required string Reference { get; set; }
    }

    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExpenseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteExpenseCommand command, CancellationToken cancellationToken)
        {
            var expenseItem = await _context.Expenses
                  .Where(q => !q.IsDeleted && command.Reference == q.ExpenseId).FirstOrDefaultAsync();

            if (expenseItem == null)
            {
                return false;
            }

            expenseItem.IsDeleted = true;

            _context.Expenses.Update(expenseItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

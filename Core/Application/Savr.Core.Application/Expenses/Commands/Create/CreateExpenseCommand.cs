using MediatR;
using Savr.Core.Application.Common.Interfaces;
using Savr.Core.Domain.Enums;
using Savr.Core.Domain.Models;

namespace Savr.Core.Application.Expenses.Commands.Create
{
    public class CreateExpenseCommand : IRequest<string>
    {
        public required string Reference { get; set; }
        public required string ExpenseType { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
    }

    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateExpenseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                ExpenseId = Guid.NewGuid().ToString(),
                Amount = request.Amount,
                Reference = request.Reference,
                ExpenseType = (ExpenseCategoryEnum)Enum.Parse(typeof(ExpenseCategoryEnum), request.ExpenseType.Replace(" ", string.Empty)),
                Date = request.Date
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return expense.ExpenseId;
        }
    }
}

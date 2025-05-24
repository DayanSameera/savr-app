using MediatR;
using Savr.Core.Application.Common.Interfaces;
using Savr.Core.Domain.Enums;
using Savr.Core.Domain.Models;

namespace Savr.Core.Application.Incomes.Commands.Create
{
    public class CreateIncomeCommand : IRequest<string>
    {
        public required string SourceName { get; set; }
        public required string IncomeCategory { get; set; }
        public required decimal Amount { get; set; }
        public string? Note { get; set; }
        public required string Date { get; set; }
    }

    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateIncomeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateIncomeCommand incomeCommand, CancellationToken cancellationToken)
        {
            var income = new Income
            {
                IncomeId = Guid.NewGuid().ToString(),
                Amount = incomeCommand.Amount,
                Note = incomeCommand.Note,
                SourceName = incomeCommand.SourceName,
                IncomeCategory = (IncomeCategoryEnum)Enum.Parse(typeof(IncomeCategoryEnum), incomeCommand.IncomeCategory),
                Date = DateTime.Parse(incomeCommand.Date)
            };

            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

            return income.IncomeId;
        }
    }
}

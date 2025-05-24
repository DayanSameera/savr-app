using Microsoft.AspNetCore.Mvc;
using Savr.Core.Application.Expenses.Commands.Create;
using Savr.Core.Application.Expenses.Queries.GetAll;

namespace Savr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Create(CreateExpenseCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenseDTO>>> Get()
        {
            return await Mediator.Send(new GetExpensesQuery());
        }
    }
}

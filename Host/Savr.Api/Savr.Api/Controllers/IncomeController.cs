using Microsoft.AspNetCore.Mvc;
using Savr.Core.Application.Expenses.Queries.GetAll;
using Savr.Core.Application.Incomes.Commands.Create;
using Savr.Core.Application.Incomes.Queries.GetAll;

namespace Savr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Create(CreateIncomeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<IncomeDTO>>> Get()
        {
            return await Mediator.Send(new GetIncomesQuery());
        }
    }
}

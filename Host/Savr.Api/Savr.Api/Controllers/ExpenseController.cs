using Microsoft.AspNetCore.Mvc;
using Savr.Core.Application.Expenses.Commands.Create;
using Savr.Core.Application.Expenses.Commands.Delete;
using Savr.Core.Application.Expenses.Queries.GetAll;
using Savr.Core.Application.Incomes.Queries.GetAll;

namespace Savr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : BaseController
    {
        /// <summary>
        /// Create record
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> Create(CreateExpenseCommand command)
        {
            try
            {
                var response = await Mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ExpenseDTO>>> Get()
        {
            try
            {
                var response = await Mediator.Send(new GetExpensesQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete expense record
        /// </summary>
        /// <param name="command">Reference Id</param>
        /// <returns></returns>
        [HttpPost("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            try
            {
                var response = await Mediator.Send(new DeleteExpenseCommand { Reference = id });

                if (!response)
                {
                    return NotFound(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

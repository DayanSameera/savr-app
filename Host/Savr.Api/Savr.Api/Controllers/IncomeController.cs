using Microsoft.AspNetCore.Mvc;
using Savr.Core.Application.Expenses.Commands.Delete;
using Savr.Core.Application.Incomes.Commands.Create;
using Savr.Core.Application.Incomes.Delete;
using Savr.Core.Application.Incomes.Queries.GetAll;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Savr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Create(CreateIncomeCommand command)
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
        public async Task<ActionResult<List<IncomeDTO>>> Get()
        {
            try
            {
                var response = await Mediator.Send(new GetIncomesQuery()); ;
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete income record
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
                var response = await Mediator.Send(new DeleteIncomeCommand { Reference = id });

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

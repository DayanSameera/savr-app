using Microsoft.AspNetCore.Mvc;
using Savr.Core.Application.Dashboard.Queries.GetDashboard;

namespace Savr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : BaseController
    {
        /// <summary>
        /// Get dashboard data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DashboardDTO>> Get()
        {
            try
            {
                var response = await Mediator.Send(new GetDashboardQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

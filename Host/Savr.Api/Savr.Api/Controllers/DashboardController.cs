using Microsoft.AspNetCore.Mvc;
using Savr.Core.Application.Dashboard.Queries.GetDashboard;

namespace Savr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<DashboardDTO>> Get()
        {
            return await Mediator.Send(new GetDashboardQuery());
        }
    }
}

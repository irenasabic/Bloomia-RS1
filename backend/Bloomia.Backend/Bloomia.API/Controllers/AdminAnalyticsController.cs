using Bloomia.Application.Modules.Admin.Analytics.Queries.Get;

namespace Bloomia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminAnalyticsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<AdminAnalyticsDto> Get([FromQuery] GetAdminAnalyticsQuery query,CancellationToken ct)
        {
            return await sender.Send(query, ct);
        }
    }
}

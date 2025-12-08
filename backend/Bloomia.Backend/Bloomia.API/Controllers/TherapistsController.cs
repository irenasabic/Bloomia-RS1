using Bloomia.Application.Modules.Articles.Commands.Update;
using Bloomia.Application.Modules.Therapists.Commands.Update;
using Bloomia.Application.Modules.Therapists.Commands.Update.ChangeTherapistPassword;
using Bloomia.Application.Modules.Therapists.Queries.GetById;
using Bloomia.Application.Modules.Therapists.Queries.List;
using Bloomia.Application.Modules.Users.Queries.GetById;
using Bloomia.Application.Modules.Users.Queries.List;

namespace Bloomia.API.Controllers
{
    [ApiController]
    [Route("api/therapists")]
    public sealed class TherapistsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<PageResult<ListTherapistsQueryDto>> List([FromQuery] ListTherapistsQuery query, CancellationToken ct)
        {
            var result = await sender.Send(query, ct);
            return result;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, THERAPIST")]
        public async Task<IActionResult> Update(int id, UpdateTherapistCommand command, CancellationToken ct)
        {
            command.Id = id;
            await sender.Send(command, ct);
            return NoContent();
        }

        [HttpPut("{id}/change-password")]
        [Authorize(Roles = "THERAPIST")]
        public async Task<IActionResult> Update(int id, ChangeTherapistPasswordCommand command, CancellationToken ct)
        {
            command.Id = id;
            await sender.Send(command, ct);
            return NoContent();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<GetTherapistByIdQueryDto> GetById(int id, CancellationToken ct)
        {
            var user = await sender.Send(new GetTherapistByIdQuery { Id = id }, ct);
            return user; // if NotFoundException -> 404 via middleware
        }
    }
}

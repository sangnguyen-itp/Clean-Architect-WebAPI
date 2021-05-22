using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Queries.GetAllUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class UsersController : BaseApiController
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllUsersParameter filter)
        {
            _logger.LogInformation("GET - api/{version}/users - GetAllUsers");
            return Ok(await Mediator.Send(new GetAllUsersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // POST api/<controller>
        [HttpPost]
        // only apply on v1.0
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

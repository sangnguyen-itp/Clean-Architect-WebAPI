using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Queries.GetAllUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class UsersController : BaseApiController
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IDistributedCache _cache;
        public UsersController(ILogger<UsersController> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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

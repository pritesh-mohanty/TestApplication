using Bidone.CodingTest.Application.User.Commands;
using Bidone.CodingTest.Application.User.Query;
using Bidone.CodingTest.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bidone.CodingTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator Mediator)
        {
            _logger = logger;
            _mediator = Mediator;
        }

        [HttpPost()]
        public async Task<ActionResult<Unit>> Post(SaveUserCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet()]
        public async Task<IEnumerable<User>> Get()
        {
            return await _mediator.Send(new GetUsersQuery());
        }
    }
}

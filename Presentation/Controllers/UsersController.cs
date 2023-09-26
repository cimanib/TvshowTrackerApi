using Application.Users.Commands;
using Application.Users.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/users")]
    public class UsersController : ApiController
    {
        public UsersController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserCommand command ,CancellationToken cancellationToken)
        {

            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) :  BadRequest(result.Error);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginQuery query, CancellationToken cancellationToken)
        {

            var result = await Sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : Unauthorized(result.Error);
        }

    }
}


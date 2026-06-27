using Internship.Application.Features.Account.Login;
using Internship.Application.Features.Account.Queries.GetAllUsers;
using Internship.Application.Features.Account.Queries.GetCurrentUser;
using Internship.Application.Features.Account.Register;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{

    public class AccountController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult((token) => Ok(new { Token = token }));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult((token) => Ok(new { Token = token }));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return result.ToActionResult(Ok);
        }
        [Authorize]
        [HttpGet("current-user")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _mediator.Send(new GetCurrentUserQuery());
            return result.ToActionResult(Ok);
        }
        //logout endpoint
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _mediator.Send(new LogoutCommand());
            return result.ToActionResult((message) => Ok(new { Message = message }));
        }
        


    }
}

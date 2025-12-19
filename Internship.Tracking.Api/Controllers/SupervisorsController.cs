using Internship.Application.Features.Supervisor.Command.Create;
using Internship.Application.Features.Supervisor.Command.Delete;
using Internship.Application.Features.Supervisor.Command.Update;
using Internship.Application.Features.Supervisor.Query.Get;
using Internship.Application.Features.Supervisor.Query.List;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{

    public class SupervisorsController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public SupervisorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSupervisors()
        {
            var query = new ListSupervisorQueries();
            var results = await _mediator.Send(query);
            return results.ToActionResult(Ok);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSupervisorById(int Id)
        {
            var query = new GetSupervisorQuery(Id);
            var result = await _mediator.Send(query);
            return result.ToActionResult(Ok);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSupervisor([FromBody]CreateSupervisorCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult((Id) => CreatedAtAction(nameof(GetSupervisorById), new { Id }, Id));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSupervisor(int Id)
        {
            var command = new DeleteSupervisorCommand(Id);
            var deletedSupervisor = await _mediator.Send(command);
            return Ok(deletedSupervisor);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateSupervisor(int Id, [FromBody] UpdateSupervisorCommand command)
        {
            if (Id != command.Id)
            {
                return BadRequest("ID mismatch between route and body");
            }
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}

using Internship.Application.Features.Application.Command.Create;
using Internship.Application.Features.Application.Command.Delete;
using Internship.Application.Features.Application.Command.Update;
using Internship.Application.Features.Application.Query.Get;
using Internship.Application.Features.Application.Query.List;
using Internship.Application.Results;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{
    
    public class ApplicationsController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public ApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var query = new ListApplicationsQuery();
            var result = await _mediator.Send(query);
            return result.ToActionResult(Ok);
            
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetApplicationById(int Id)
        {
            var query = new GetApplicationQuery(Id);
            var result = await _mediator.Send(query);
            return result.ToActionResult(Ok);

      
        }
        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromBody] CraetaAppliactionCommand command)
        {
            var result = await _mediator.Send(command);

            return result.ToActionResult((Id) => CreatedAtAction(nameof(GetApplicationById), new { Id }, Id));

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteApplication(int Id)
        {
            var command = new DeleteApplicationCommand(Id);
            var deletedApplication = await _mediator.Send(command);
            return Ok(deletedApplication);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateApplication(int Id, [FromBody] UpdateApplicationCommand command)
        {
            if (Id != command.Id)
                return BadRequest("Id from route does not match Id from body.");

            var result = await _mediator.Send(command) ;

            return result.ToActionResult();

        }
    }
}

using Internship.Application.Features.Evaluation.Command.Create;
using Internship.Application.Features.Evaluation.Command.Delete;
using Internship.Application.Features.Evaluation.Command.Update;
using Internship.Application.Features.Evaluation.Query.Get;
using Internship.Application.Features.Evaluation.Query.List;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{

    public class EvaluationsController : ApiBaseController
    {
        private readonly IMediator mediator;
        public EvaluationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEvaluations()
        {
            var results = await mediator.Send(new ListEvaluationsQuery());
            return results.ToActionResult(Ok);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEvaluationById(int Id)
        {
            var result = await mediator.Send(new GetEvaluationQuery(Id));
            return result.ToActionResult(Ok);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvaluation([FromBody] CreateEvaluationCommand command)
        {
            var result = await mediator.Send(command);
            return result.ToActionResult((Id) => CreatedAtAction(nameof(GetEvaluationById), new { Id }, Id));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEvaluation(int Id)
        {
            var result = await mediator.Send(new DeleteEvaluationCommand(Id));
            return Ok(result);

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateEvaluation(int Id, [FromBody] UpdateEvaluationCommand command)
        {
            if (Id != command.Id)
            {
                return BadRequest("Id in URL does not match Id in request body.");
            }
            var result = await mediator.Send(command);
            return result.ToActionResult();
        }
    }
}

using Internship.Application.Features.Report.Command.Create;
using Internship.Application.Features.Report.Command.Delete;
using Internship.Application.Features.Report.Command.Update;
using Internship.Application.Features.Report.Query.Get;
using Internship.Application.Features.Report.Query.List;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{
 
    public class ReportsController : ApiBaseController
    {
        private readonly IMediator mediator;
        public ReportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var results = await mediator.Send(new ListReportsQuery());
            return results.ToActionResult(Ok);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetReportById(int Id)
        {
            var result = await mediator.Send(new GetReportQuery(Id));
            return result.ToActionResult(Ok);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportCommand command)
        {
            var result = await mediator.Send(command);
            return result.ToActionResult((Id) => CreatedAtAction(nameof(GetReportById), new { Id }, Id));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReport(int Id)
        {
            var result = await mediator.Send(new DeleteReportCommand(Id));
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateReport(int Id, [FromBody] UpdateReportCommand command)
        {
            if (Id != command.Id)
            {
                return BadRequest("ID mismatch between route and body");
            }
            var result = await mediator.Send(command);
            return result.ToActionResult();
        }
    }
}

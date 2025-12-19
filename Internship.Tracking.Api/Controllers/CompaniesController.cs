using Internship.Application.Features.Company.Command.Create;
using Internship.Application.Features.Company.Command.Delete;
using Internship.Application.Features.Company.Command.Update;
using Internship.Application.Features.Company.Queries.Get;
using Internship.Application.Features.Company.Queries.List;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{
    
    public class CompaniesController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult((Id) => CreatedAtAction(nameof(GetCompanyById), new { Id }, Id));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCompany(int Id)
        {
            var command = new DeleteCompanyCommand(Id);
            var deletedCompanyId = await _mediator.Send(command);
            return Ok(deletedCompanyId);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var query = new ListCompaniesQuery();
            var results = await _mediator.Send(query);
            return results.ToActionResult(Ok);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCompanyById(int Id)
        {
            var query = new GetCompanyQuery(Id);
            var result = await _mediator.Send(query);
            return result.ToActionResult(Ok);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCompany(int Id, [FromBody] UpdateCompanyCommand command)
        {
            if (Id != command.Id)
            {
                return BadRequest("ID in URL does not match ID in body.");
            }
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}

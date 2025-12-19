using Internship.Application.Features.IntenshipOffer.Command.Create;
using Internship.Application.Features.IntenshipOffer.Command.Delete;
using Internship.Application.Features.IntenshipOffer.Command.Update;
using Internship.Application.Features.IntenshipOffer.Queries.Get;
using Internship.Application.Features.IntenshipOffer.Queries.List;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{

    public class InternshipOffersController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public InternshipOffersController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> CreateInternshipOffer([FromBody] CreateInternshipOfferCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult((Id) => CreatedAtAction(nameof(GetInternshipOfferById), new { Id }, Id));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteInternshipOffer(int Id)
        {
            var command = new DeleteInternshipCommmand(Id);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetInternshipOfferById(int Id)
        {
            var query = new GetInternshipQuery(Id);
            var result = await _mediator.Send(query);
            return result.ToActionResult(Ok);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInternshipOffers()
        {
            var query = new ListInternshipQueries();
            var results = await _mediator.Send(query);
            return results.ToActionResult(Ok);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateInternshipOffer(int Id, [FromBody] UpdateInternshipCommand command)
        {
            if (Id != command.Id)
            {
                return BadRequest("Id in URL does not match Id in body.");
            }
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}

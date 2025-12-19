using Internship.Application.Features.Student.Command.Create;
using Internship.Application.Features.Student.Command.Delete;
using Internship.Application.Features.Student.Command.Update;
using Internship.Application.Features.Student.Query.Get;
using Internship.Application.Features.Student.Query.List;
using Internship.Tracking.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Controllers
{
   
    public class StudentsController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult((Id) => CreatedAtAction(nameof(GetById), new { Id }, Id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new ListStudentQueries();
            var results = await _mediator.Send(query);
            return results.ToActionResult(Ok);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetStudentQuery(Id);
            var result = await _mediator.Send(query);
            return result.ToActionResult(Ok);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var command = new DeleteStudentCommand(Id);
            var deletedStudentId = await _mediator.Send(command);
            return Ok(deletedStudentId);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult>UpdateStudent(int Id, [FromBody] UpdateStudentCommand command)
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

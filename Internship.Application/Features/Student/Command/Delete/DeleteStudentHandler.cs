using Internship.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Command.Delete
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Domain.Models.Student>().GetByIdAsync(request.Id);
            if (student == null)
            {
                return false;
            }
            _unitOfWork.Repository<Domain.Models.Student>().Delete(student);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}

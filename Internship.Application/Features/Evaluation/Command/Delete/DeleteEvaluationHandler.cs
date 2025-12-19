using Internship.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Command.Delete
{
    public class DeleteEvaluationHandler : IRequestHandler<DeleteEvaluationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEvaluationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteEvaluationCommand request, CancellationToken cancellationToken)
        {
            var evaluation = await _unitOfWork.Repository<Domain.Models.Evaluation>().GetByIdAsync(request.Id);
            if (evaluation == null)
            {
                return false;
            }
            _unitOfWork.Repository<Domain.Models.Evaluation>().Delete(evaluation);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}

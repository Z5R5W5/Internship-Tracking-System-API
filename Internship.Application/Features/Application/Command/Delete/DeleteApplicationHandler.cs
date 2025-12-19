using Internship.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Command.Delete
{
    public class DeleteApplicationHandler : IRequestHandler<DeleteApplicationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteApplicationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _unitOfWork.Repository<Domain.Models.Application>().GetByIdAsync(request.Id);
            if (application == null)
            {
                return false;
            }
            _unitOfWork.Repository<Domain.Models.Application>().Delete(application);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}

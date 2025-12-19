using Internship.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Delete
{
    public class DeleteSupervisorHandler : IRequestHandler<DeleteSupervisorCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSupervisorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteSupervisorCommand request, CancellationToken cancellationToken)
        {
            var supervisor = await _unitOfWork.Repository<Domain.Models.Supervisor>().GetByIdAsync(request.Id);
            if (supervisor == null)
            {
                throw new Exception("Supervisor not found");
            }
            _unitOfWork.Repository<Domain.Models.Supervisor>().Delete(supervisor);
            await _unitOfWork.CompleteAsync();
            return true;

        }
    }
}

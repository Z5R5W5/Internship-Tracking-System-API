using Internship.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Command.Delete
{
    public class DeleteReportHandler : IRequestHandler<DeleteReportCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteReportHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            var report = await unitOfWork.Repository<Domain.Models.Report>().GetByIdAsync(request.Id);
            if (report == null)
            {
                return false;
            }
            unitOfWork.Repository<Domain.Models.Report>().Delete(report);
            await unitOfWork.CompleteAsync();
            return true;
        }
    }
}

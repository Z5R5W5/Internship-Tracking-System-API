using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Command.Create
{
    public class CreateSupervisorHandler : IRequestHandler<CreateSupervisorCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSupervisorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> Handle(CreateSupervisorCommand request, CancellationToken cancellationToken)
        {
            var supervisor = new Domain.Models.Supervisor
            {
                FullName = request.FullName,
                Email = request.Email,
                Role = request.Role,
                InternshipOfferId = request.InternshipOfferId
            };
            await  _unitOfWork.Repository<Domain.Models.Supervisor>().AddAsync(supervisor);
            await _unitOfWork.CompleteAsync();
            return Result<int>.Success( supervisor.Id);


        }
    }
}

using Internship.Application.Features.Supervisor.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Query.Get
{
    public class GetSupervisorHandler : IRequestHandler<GetSupervisorQuery, Result<SupervisorResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSupervisorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<SupervisorResponse>> Handle(GetSupervisorQuery request, CancellationToken cancellationToken)
        {
            var supervisor = await _unitOfWork.Repository<Domain.Models.Supervisor>().GetByIdAsync(request.Id);
            if (supervisor == null)
            {
                return Result<SupervisorResponse>.Failure("Supervisor not found", 404);
            }
            var response = new SupervisorResponse
            {
                Id = supervisor.Id,
                FullName = supervisor.FullName,
                Email = supervisor.Email,
                Role = supervisor.Role
            };
            return Result < SupervisorResponse >.Success( response);
        }
    }
}

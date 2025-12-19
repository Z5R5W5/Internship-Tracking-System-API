using Internship.Application.Features.Supervisor.Dtos;
using Internship.Application.Interfaces;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Supervisor.Query.List
{
    public class ListSupervisorHandler : IRequestHandler<ListSupervisorQueries, Result<List<SupervisorResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListSupervisorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<List<SupervisorResponse>>> Handle(ListSupervisorQueries request, CancellationToken cancellationToken)
        {
            var supervisors = await _unitOfWork.Repository<Domain.Models.Supervisor>().GetAllAsync();
            if (supervisors == null || !supervisors.Any())
            {
                return Result<List<SupervisorResponse>>.Failure("No supervisors found", 404);
            }
            var response = supervisors.Select(supervisor => new SupervisorResponse
            {
                Id = supervisor.Id,
                FullName = supervisor.FullName,
                Email = supervisor.Email,
                Role = supervisor.Role
            }).ToList();
            return Result < List < SupervisorResponse >>.Success( response);
        }
    }
}

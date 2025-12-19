using Internship.Application.Features.Company.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Company.Queries.List
{
    public record ListCompaniesQuery
    (

    ) : IRequest<Result<List<CompanyResponse>>>;
}

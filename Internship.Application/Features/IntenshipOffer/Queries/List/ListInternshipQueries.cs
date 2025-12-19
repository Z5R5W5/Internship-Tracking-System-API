using Internship.Application.Features.IntenshipOffer.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Queries.List
{
    public record ListInternshipQueries
    (): IRequest<Result<List<InternshipResponse>>>;
}

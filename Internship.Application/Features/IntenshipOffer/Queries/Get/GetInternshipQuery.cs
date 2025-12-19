using Internship.Application.Features.IntenshipOffer.Dtos;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.IntenshipOffer.Queries.Get
{
    public record GetInternshipQuery
    (int Id):IRequest<Result<InternshipResponse>>;
}

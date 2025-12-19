using FluentValidation;
using Internship.Application.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .SelectMany(x => x.Errors)
                    .Where(x => x != null)
                    .ToList();

                if (failures.Any())
                {
                    var errorDict = failures
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(x => x.ErrorMessage).ToArray()
                        );

                    if (typeof(TResponse).IsGenericType &&
                        typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
                    {
                        var validationMethod = typeof(Result<>)
                            .MakeGenericType(typeof(TResponse).GenericTypeArguments[0])
                            .GetMethod("ValidationFailure");

                        var result = validationMethod!.Invoke(null, new object[] { errorDict });

                        return (TResponse)result!;
                    }

                    return (TResponse)(object)Result.ValidationFailure(errorDict);
                }
            }

            return await next();
        }
    }

}

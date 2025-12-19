using Internship.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Tracking.Api.Extentions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult<T>(this Result<T> result, Func<T, IActionResult> onSuccess)
        {
            if (result.IsFailure)
            {
                if (result.ValidationErrors != null)
                    return new BadRequestObjectResult(result);
                if (result.ErrorCode == 404)
                    return new NotFoundObjectResult(result);
                return new ObjectResult(result) { StatusCode = 500 };
            }
            return onSuccess(result.Value!);
        }

        public static IActionResult ToActionResult(this Result result)
        {
            if (result.IsFailure)
            {
                if (result.ValidationErrors != null)
                    return new BadRequestObjectResult(result);
                if (result.ErrorCode == 404)
                    return new NotFoundObjectResult(result);
                return new ObjectResult(result) { StatusCode = 500 };
            }
            return new OkResult();
        }
    }
}

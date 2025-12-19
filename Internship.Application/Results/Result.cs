using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? Error { get; }
        public int? ErrorCode { get; } // optional numeric code
        public IDictionary<string, string[]?>? ValidationErrors { get; }

        protected Result(bool isSuccess, string? error, int? errorCode = null, IDictionary<string, string[]?>? validationErrors = null)
        {
            IsSuccess = isSuccess;
            Error = error;
            ErrorCode = errorCode;
            ValidationErrors = validationErrors;
        }

        public static Result Success() => new Result(true, null);

        public static Result Failure(string error, int? errorCode = null)
            => new Result(false, error, errorCode);

        public static Result ValidationFailure(IDictionary<string, string[]?> validationErrors)
            => new Result(false, "Validation failed", 400, validationErrors);
    }

    public class Result<T> : Result
    {
        public T? Value { get; }

        protected Result(T? value, bool isSuccess, string? error, int? errorCode = null, IDictionary<string, string[]?>? validationErrors = null)
            : base(isSuccess, error, errorCode, validationErrors)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new Result<T>(value, true, null);

        public static new Result<T> Failure(string error, int? errorCode = null)
            => new Result<T>(default, false, error, errorCode);

        public static Result<T> ValidationFailure(IDictionary<string, string[]?> validationErrors)
            => new Result<T>(default, false, "Validation failed", 400, validationErrors);
    }

}

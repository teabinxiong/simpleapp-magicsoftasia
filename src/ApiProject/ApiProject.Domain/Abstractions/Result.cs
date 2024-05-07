using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiProject.Domain.Abstractions
{
		public class CustomResult
		{
			public ResultStatus Status { get; set; }

			public Error Error { get; set; }

			protected internal CustomResult(ResultStatus status, Error error)
			{

				Status = status;
				Error = error;
			}

			public static CustomResult Success() => new CustomResult(ResultStatus.Success, Error.None);
			public static CustomResult Failure(Error error) => new CustomResult(ResultStatus.Failed, error);

			public static CustomResult<TValue> Success<TValue>(TValue value) => new(value, ResultStatus.Success, Error.None);

			public static CustomResult<TValue> Failure<TValue>(Error error) => new(default, ResultStatus.Failed, error);

			public static CustomResult<TValue> Create<TValue>(TValue? value) =>
				 value is not null ? Success(value) : Failure<TValue>(Error.NullValue);


		}

		public class CustomResult<T> : CustomResult
	{
			private readonly T? _result;

			public static implicit operator CustomResult<T>(T? value) => Create(value);

			protected internal CustomResult(T? value, ResultStatus status, Error error) : base(status, error)
			{
				_result = value;
			}

			[NotNull]
			public T Result => Status == ResultStatus.Success ? _result! : throw new InvalidOperationException("Failure result cannot be accessed.");
		}

		public enum ResultStatus
		{
			Success = 1,
			Failed = 0
		}
	
}

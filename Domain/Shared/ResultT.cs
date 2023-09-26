using System;
namespace Domain.Shared
{
	public class Result<TValue> : Result
	{
		private readonly TValue _value;

		protected internal Result(TValue? data, bool isSuccess, Error error)
			:base(isSuccess, error)
			{
			   _value= data;
			}

		public TValue Data => IsSuccess ? _value : throw new InvalidOperationException();
    }
}


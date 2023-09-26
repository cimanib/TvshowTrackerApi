namespace Domain.Shared
{
    public class Result
	{
		protected internal Result(bool isSuccess, Error error)
		{
			if(isSuccess && error == Error.None)
			{

				throw new InvalidOperationException();
			}
			if(!IsSuccess && error == Error.None)
			{

                throw new InvalidOperationException();
            }
			IsSuccess = isSuccess;
			Error = error;

        }

		public Error Error { get;}
		public bool IsSuccess { get;}
        public bool IsFailure
        {
            get
            {
                return !IsSuccess;
            }
        }

        public static Result<TValue> Success<TValue>(TValue data)
        {
            return new Result<TValue>(data, true, Error.None);
        }

        public static Result Success()
        {
            return new Result(true, Error.None);
        }
        
        public static Result<TValue> Create<TValue>(TValue value, Error error)
           where TValue : class
        {
            return value is null ? Failure<TValue>(error) : Success(value);
        }

        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }

        public static Result<TValue> Failure<TValue>(Error error)
        {
            return new Result<TValue>(default!, false, error);
        }

        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }
            }

            return Success();
        }
    }
	
}


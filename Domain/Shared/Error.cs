﻿namespace Domain.Shared
{
    public class Error : IEquatable<Error>

	{
        public static readonly Error None = new Error(string.Empty, string.Empty);
		public static readonly Error NullValue = new Error("Error.NullValue", "The specified value is null");


        public Error(string code ,string message)
		{
			Code = code;
			Message = message;
			
		}
		public string Code { get;}
		public string Message { get;}
		public static implicit operator string(Error error) => error.Code;

        public static bool operator ==(Error? a, Error b)
        {
            if(a is null && b is null && a.Equals(b))

			    return true;

			if (a is null || b is null)

				return false;

			return false;


        }
        public static bool operator !=(Error? a, Error b)
        {
            return !(a == b);
        }

        public bool Equals(Error? other)
        {
            if (other is null)

                return false;
            if(other.GetType() !=GetType())

                return false;

            return (other.Code == Code);
           
        }
    }
}


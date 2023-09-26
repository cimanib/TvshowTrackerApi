using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.Users.Queries.Login
{
    public class UserLoginQuery :IQuery<UserResponse>
	{
		public string Email { get; set; }
		public string Password { get; set; }

	}
}


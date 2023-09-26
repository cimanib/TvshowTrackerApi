using System;
using Application.Abstractions;

namespace Application.Users.Commands
{
	public class CreateUserCommand : ICommand
	{
		public string Name { get; set; }
		public string EmailAddress { get; set; }
		public string Password { get; set; }

	}
}


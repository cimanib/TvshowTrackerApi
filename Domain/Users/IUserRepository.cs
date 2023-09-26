namespace Domain.Users
{
    public interface IUserRepository
	{
		void Add(User user);
		Task<bool> IsUniqueEmail(string emailAddress);
		Task<User?> Get(User user);
	}
}


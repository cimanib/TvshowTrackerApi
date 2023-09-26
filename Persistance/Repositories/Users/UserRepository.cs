using Domain.Users;

namespace Persistance.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(User user)
        {
             applicationDbContext.Users.Add(user);
        }

        public Task<bool> IsUniqueEmail(string emailAddress)
        {
           var result = applicationDbContext.Users
                .Where(User => User.EmailAddress == emailAddress)
                .FirstOrDefault();

            return Task.FromResult(result?.EmailAddress == string.Empty);
        }

        public Task<User?> Get(User user)
        {
            var result = applicationDbContext.Users
                 .Where(u => u.EmailAddress == user.EmailAddress)
                .FirstOrDefault();

            return Task.FromResult(result);
        }
    }
}


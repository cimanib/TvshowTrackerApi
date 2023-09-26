using Application.Abstractions.Messaging;
using Application.Helpers;
using Domain.Shared;
using Domain.Users;

namespace Application.Users.Queries.Login
{
    public class UserLoginQueryHandler : IQueryHandler<UserLoginQuery, UserResponse>
    {

        private readonly IUserRepository userRepository;

        public UserLoginQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<Result<UserResponse>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {

            //TODO: Check email uniqueness
            var hashedPassword = request.Password.GetPasswordHash();
            var user = new User
            {
                EmailAddress = request.Email,
                Password = request.Password

            };
            var response = await userRepository.Get(user);

            if (response is null)

                return Result.Failure<UserResponse>(new Error("Login.Failure", "username or password is incorrect"));

             if(response.Password != hashedPassword)

                return Result.Failure<UserResponse>(new Error("Login.Failure", "username or password is incorrect"));


            return Result.Success(new UserResponse { UserId = response.Id.ToString(),Email = response.EmailAddress});


        }
    }
}


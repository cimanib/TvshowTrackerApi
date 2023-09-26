using Application.Abstractions.Messaging;
using Application.Helpers;
using Domain.Abstractions;
using Domain.Shared;
using Domain.Users;


namespace Application.Users.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {

        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateUserCommandHandler(IUserRepository userRepository , IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;

        }
        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = request.Password.GetPasswordHash();
            var user = new User
            {
                EmailAddress = request.EmailAddress,
                FullName = request.Name,
                Password = hashedPassword
            };

            userRepository.Add(user);

            await unitOfWork.SaveChanges(cancellationToken);

            return Result.Success();
        }
    }
}


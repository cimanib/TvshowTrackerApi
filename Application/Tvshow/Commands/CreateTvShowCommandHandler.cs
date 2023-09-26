using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Shared;
using Domain.TvShow;

namespace Application.Tvshow.Commands
{
    public class CreateTvShowCommandHandler : ICommandHandler<CreateTVshowCommand>
    {

        private readonly ITvShowRepository tvShowRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateTvShowCommandHandler(ITvShowRepository tvShowRepository, IUnitOfWork unitOfWork)
        {
            this.tvShowRepository = tvShowRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateTVshowCommand request, CancellationToken cancellationToken)
        {

            var tvshow = new TvShow
            {
                Description = request.Description,
                Name = request.Name
            };

            tvShowRepository.Add(tvshow);

            await unitOfWork.SaveChanges(cancellationToken);

            return Result.Success();

        }
    }
}


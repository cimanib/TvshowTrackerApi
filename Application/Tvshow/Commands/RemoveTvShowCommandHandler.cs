using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Shared;
using Domain.TvShow;

namespace Application.Tvshow.Commands
{
    public class RemoveTvShowCommandHandler : ICommandHandler<RemoveTvShowCommand>
    {

        private readonly ITvShowRepository tvShowRepository;
        private readonly IUnitOfWork unitOfWork;

        public RemoveTvShowCommandHandler(
            ITvShowRepository tvShowRepository,
            IUnitOfWork unitOfWork)
        {
            this.tvShowRepository = tvShowRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(RemoveTvShowCommand request, CancellationToken cancellationToken)
        {

            var tvshow = tvShowRepository.Get(new Guid(request.TvSHowId));

            if (tvshow is null)

                return Result.Failure<RemoveTvShowCommand>(new Error("TvShow.Remove", $"The tv show with id {request.TvSHowId} is not found"));
            tvShowRepository.Remove(tvshow);

            await unitOfWork.SaveChanges(cancellationToken);

            return Result.Success();

        }
    }
}


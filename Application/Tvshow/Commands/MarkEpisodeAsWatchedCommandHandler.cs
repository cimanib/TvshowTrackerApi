using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Shared;
using Domain.UserEpisodes;

namespace Application.Tvshow.Commands
{
    public class MarkEpisodeAsWatchedCommandHandler : ICommandHandler<MarkEpisodeAsWatchedCommand>
    {
        private readonly IUserEpisodeRepository userEpisodeRepository;
        private readonly IUnitOfWork unitOfWork;

        public MarkEpisodeAsWatchedCommandHandler(
            IUserEpisodeRepository userEpisodeRepository,
            IUnitOfWork unitOfWork)
        {
            this.userEpisodeRepository = userEpisodeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(MarkEpisodeAsWatchedCommand request, CancellationToken cancellationToken)
        {

             userEpisodeRepository.MarkEpsideWatched(userId:request.UserId,episodeId:request.EpisodeId);

             await unitOfWork.SaveChanges(cancellationToken);

            return Result.Success();

        }
    }
}


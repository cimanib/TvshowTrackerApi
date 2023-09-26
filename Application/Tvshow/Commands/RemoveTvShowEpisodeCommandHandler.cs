using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Shared;
using Domain.TvShow;

namespace Application.Tvshow.Commands
{
    public class RemoveTvShowEpisodeCommandHandler : ICommandHandler<RemoveTvShowEpisodeCommand>
    {

        private readonly ITvShowRepository tvShowRepository;
        private readonly IEpisodeRepository episodeRepository;
        private readonly IUnitOfWork unitOfWork;

        public RemoveTvShowEpisodeCommandHandler(
            ITvShowRepository tvShowRepository,
            IEpisodeRepository episodeRepository,
            IUnitOfWork unitOfWork )
        {
            this.tvShowRepository = tvShowRepository;
            this.episodeRepository = episodeRepository;
            this.unitOfWork = unitOfWork;

        }
        public async Task<Result> Handle(RemoveTvShowEpisodeCommand request, CancellationToken cancellationToken)
        {
           
           var tvshow = tvShowRepository.Get(new Guid(request.TvShowId));

            if (tvshow is not null)
            {
                var episode = tvshow.Episodes
                    .First(c => c.Id == new Guid(request.EpisodeId));

                episodeRepository.Remove(episode);
            }
            await unitOfWork.SaveChanges(cancellationToken);

            return Result.Success();
        }
    }
}


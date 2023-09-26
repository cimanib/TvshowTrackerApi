using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Shared;
using Domain.TvShow;

namespace Application.Tvshow.Commands
{
    public class CreateTvShowEpisodeCommandHandler : ICommandHandler<CreateTvShowEpisodeCommand>
    {

        private readonly IEpisodeRepository episodeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITvShowRepository tvShowRepository;

        public CreateTvShowEpisodeCommandHandler(
            ITvShowRepository tvShowRepository,
            IEpisodeRepository episodeRepository,
            IUnitOfWork unitOfWork)
        {
            this.episodeRepository = episodeRepository;
            this.unitOfWork = unitOfWork;
            this.tvShowRepository = tvShowRepository;

        }
        public async Task<Result> Handle(CreateTvShowEpisodeCommand request, CancellationToken cancellationToken)
        {

            var tvshow = tvShowRepository.Get(new Guid(request.TvShowId));

            if (tvshow is null)
                return Result.Failure(new Error("tvshow.NotFound", $"The tv show with the id {request.TvShowId} does not exist "));

            var episode = new Episode
            {
                Name = request.Name,
                Description = request.Description,
                CoverImageUrl= request.CoverImageUrl,
                SourceUrl = request.SourceUrl
            };

            episodeRepository.Add(request.TvShowId,episode);

            await unitOfWork.SaveChanges(cancellationToken);

            return Result.Success();


        }
    }
}


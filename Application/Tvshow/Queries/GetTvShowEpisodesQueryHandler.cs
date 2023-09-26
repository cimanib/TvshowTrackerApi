using Application.Abstractions.Messaging;
using Domain.Shared;
using Domain.TvShow;

namespace Application.Tvshow.Queries
{
    public class GetTvShowEpisodesQueryHandler : IQueryHandler<GetTvShowEpisodesQuery>
    {

        private readonly ITvShowRepository tvShowRepository;

        public GetTvShowEpisodesQueryHandler(ITvShowRepository tvShowRepository)
        {
            this.tvShowRepository = tvShowRepository;
        }


        public async Task<Result> Handle(GetTvShowEpisodesQuery request, CancellationToken cancellationToken)
        {

            var response = tvShowRepository.Get(new Guid(request.TvshowId));

            if(response is null)
               return Result.Failure(new Error("TvShow.NotFound", $"tv show with id {request.TvshowId} not found" ));

           return Result.Success(data: response);
        }
    }
}


using Application.Abstractions.Messaging;
using Domain.Shared;
using Domain.TvShow;

namespace Application.Tvshow.Queries
{
    public class GetTvShowQueryHandler : IQueryHandler<GetTvShowsQuery>
    {

        private readonly ITvShowRepository tvShowRepository;
        public GetTvShowQueryHandler(ITvShowRepository tvShowRepository)
        {
            this.tvShowRepository = tvShowRepository;
        }
        public async Task<Result> Handle(GetTvShowsQuery request, CancellationToken cancellationToken)
        {


            var response = await tvShowRepository.GetAll();

            if (response is null)

                return Result.Failure(new Error("TvShows.NotFound", "No available tv shows"));
             var res = Result.Success<List<TvShow>>(data: response);
            return res;


        }
    }
}


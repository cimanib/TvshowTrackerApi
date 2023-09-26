using Domain.TvShow;

namespace Persistance.Repositories.Episodes
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EpisodeRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void Add(string tvshowId, Episode episode)
        {

            applicationDbContext.TvShows
                .Where(c => c.TvShowId == new Guid(tvshowId))?
                .FirstOrDefault()?.Episodes.Add(episode);
        }

        public void Remove(Episode episode)
        {
            applicationDbContext.Episodes.Remove(episode);
        }


    }
}


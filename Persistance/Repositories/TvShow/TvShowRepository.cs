using Domain.TvShow;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.TvShow
{
    public class TvShowRepository : ITvShowRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public TvShowRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(Domain.TvShow.TvShow show)
        {
            applicationDbContext.TvShows.Add(show);
        }

        public Domain.TvShow.TvShow? Get(Guid tvshowId)
        {
            return applicationDbContext.TvShows
                        .AsNoTracking()
                        .Where(c => c.TvShowId == tvshowId)?
                        .Include(c => c.Episodes)
                        .FirstOrDefault();
                        
        }

        public Task<List<Domain.TvShow.TvShow>?> GetAll()
        {
            var result = applicationDbContext?.TvShows
                .AsNoTracking()
                .Include(c => c.Episodes)
                .ToList();

            return Task.FromResult(result);

        }

        public void Remove(Domain.TvShow.TvShow tvShow)
        {
            applicationDbContext.TvShows.Remove(tvShow);    
        }

        public void Update(Domain.TvShow.TvShow tvShow)
        {
            applicationDbContext.Update(tvShow);
        }
    }
}


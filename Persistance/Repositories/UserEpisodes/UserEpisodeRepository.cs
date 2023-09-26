


using Domain.UserEpisodes;

namespace Persistance.Repositories.UserEpisodes
{
	public class UserEpisodeRepository : IUserEpisodeRepository
    {

        private readonly ApplicationDbContext applicationDbContext;
		public UserEpisodeRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;

        }

        public void MarkEpsideWatched(string userId, string episodeId)
        {

            UserEpisode userEpisode = new();

            userEpisode.Episode.Id = new Guid(episodeId);
            userEpisode.User.Id = new Guid(userId);

            applicationDbContext.UserEpisodes.Add(userEpisode);
        }
    }
}


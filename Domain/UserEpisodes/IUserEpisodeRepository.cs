namespace Domain.UserEpisodes
{
    public interface IUserEpisodeRepository
	{
        void MarkEpsideWatched(string userId, string episodeId);

    }
}


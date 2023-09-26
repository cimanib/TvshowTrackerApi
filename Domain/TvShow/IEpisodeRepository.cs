namespace Domain.TvShow
{
    public interface IEpisodeRepository
	{
		void Add(string tvshowId,Episode episode);
        void Remove(Episode episode);

    }
}


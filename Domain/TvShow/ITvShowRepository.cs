namespace Domain.TvShow
{
    public interface ITvShowRepository
	{
		void Add(TvShow show);
		void Update(TvShow tvShow);
		TvShow? Get(Guid tvshowId);
		Task<List<TvShow?>> GetAll();
        void Remove(TvShow tvshowId);
	}
}


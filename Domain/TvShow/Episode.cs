using Domain.UserEpisodes;

namespace Domain.TvShow
{
    public class Episode
	{
		public Guid Id { get; set; }
		public string CoverImageUrl { get; set; }
		public string SourceUrl { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<UserEpisode> UserEpisodes { get; set; }

	}
}


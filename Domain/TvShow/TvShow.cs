namespace Domain.TvShow
{
    public class TvShow
	{
		public TvShow()
		{
            Episodes = new HashSet<Episode>();

        }
		public Guid TvShowId { get; set; }
		public string CoverImageUrl { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public  ICollection<Episode> Episodes { get; set; }

	}
}


using Application.Abstractions.Messaging;

namespace Application.Tvshow.Queries
{
    public class GetTvShowEpisodesQuery :IQuery
	{
		public string TvshowId { get; set; }
	}
}


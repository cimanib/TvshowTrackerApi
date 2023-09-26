using Application.Abstractions;
using Domain.TvShow;

namespace Application.Tvshow.Commands
{
    public class CreateTvShowEpisodeCommand : ICommand
	{
		public string TvShowId { get; set; }
        public string CoverImageUrl { get; set; }
        public string SourceUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}


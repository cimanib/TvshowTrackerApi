using Application.Abstractions;

namespace Application.Tvshow.Commands
{
    public class MarkEpisodeAsWatchedCommand : ICommand
	{
		public string UserId { get; set; }
		public string EpisodeId { get; set; }


	}
}


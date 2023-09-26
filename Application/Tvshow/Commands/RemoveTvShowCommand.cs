using Application.Abstractions;

namespace Application.Tvshow.Commands
{
    public class RemoveTvShowCommand : ICommand
	{
		public string TvSHowId { get; set; }

	}
}


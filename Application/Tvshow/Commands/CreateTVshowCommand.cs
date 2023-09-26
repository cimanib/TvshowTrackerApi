using Application.Abstractions;
using Domain.TvShow;

namespace Application.Tvshow.Commands
{
    public class CreateTVshowCommand :ICommand
	{

		public string Name { get; set; }
		public string Description { get; set; }
	}
}


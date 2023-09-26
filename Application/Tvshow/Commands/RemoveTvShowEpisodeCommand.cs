

using Application.Abstractions;

namespace Application.Tvshow.Commands
{
    public class RemoveTvShowEpisodeCommand : ICommand
    {

        public string TvShowId { get; set; }
        public string EpisodeId { get; set; }

    }
}


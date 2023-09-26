using Application.Tvshow.Commands;
using Application.Tvshow.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/tvshows")]
    public class TvShowsController : ApiController
    {
        public TvShowsController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateTvShow([FromBody] CreateTVshowCommand command ,CancellationToken cancellationToken)
        {

            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) :  BadRequest(result.Error);
        }
        [HttpDelete]
        public async Task<IActionResult> CreateEpisode([FromQuery] RemoveTvShowCommand command, CancellationToken cancellationToken)
        {

            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpPost]
        [Route("episodes")]
        public async Task<IActionResult> CreateEpisode([FromBody] CreateTvShowEpisodeCommand command, CancellationToken cancellationToken)
        {
            
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
        [HttpDelete]
        [Route("{tvshowId}/episodes/{episodeId}")]
        public async Task<IActionResult> RemoveEpisode(string tvshowId,string episodeId, CancellationToken cancellationToken)
        {
            var command = new RemoveTvShowEpisodeCommand
            {
                EpisodeId = episodeId,
                TvShowId = tvshowId

            };
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet]
        [Route("{tvshowId}/episodes")]
        public async Task<IActionResult> GetEpisodesForATvShow(string tvshowId, CancellationToken cancellationToken)
        {
            var query = new GetTvShowEpisodesQuery
            {
                TvshowId= tvshowId
            };
            var result = await Sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetTvShows(CancellationToken cancellationToken)
        {
           
            var result = await Sender.Send(new GetTvShowsQuery(), cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }

    }
}


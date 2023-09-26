using Application.Tvshow.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api")]
    public class UserEpisodesController : ApiController
    {
        public UserEpisodesController(ISender sender) : base(sender)
        {
        }

        [HttpPut]
        [Route("users{userId}/episodes/{episodeId}")]
        public async Task<IActionResult> MarkUserEpisodeWatched(string userId,string episodeId,CancellationToken cancellationToken)
        {
            var command = new MarkEpisodeAsWatchedCommand()
            {
                UserId = userId,
                EpisodeId= episodeId
            };
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}


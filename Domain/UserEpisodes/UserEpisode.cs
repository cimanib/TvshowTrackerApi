using Domain.TvShow;
using Domain.Users;

namespace Domain.UserEpisodes
{
    public class UserEpisode
	{

		public string Id { get; set; }
		public User User { get; set; }
		public Episode Episode { get; set; }

	}
}
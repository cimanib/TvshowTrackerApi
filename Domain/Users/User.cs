using Domain.TvShow;
using Domain.UserEpisodes;

namespace Domain.Users
{
    public class User
	{

		public Guid Id { get; set; }
		public  string FullName { get; set; }
		public  string EmailAddress { get;  set; }
		public  string Password { get;  set; }
		public ICollection<Episode> Episodes { get; set; }
		public ICollection<UserEpisode> UserEpisodes { get; set; }


	}
}

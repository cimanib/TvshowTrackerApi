using Domain.TvShow;
using Domain.UserEpisodes;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ApplicationDbContext : DbContext
	{

        public ApplicationDbContext()
        {

        }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		   
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Episode> Episodes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<UserEpisode> UserEpisodes { get; set; }
    }
}


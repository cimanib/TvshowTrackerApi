using Domain.TvShow;
using Domain.UserEpisodes;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories.Episodes;
using Persistance.Repositories.TvShow;
using Persistance.Repositories.UserEpisodes;
using Persistance.Repositories.Users;

namespace Persistance
{
    public static  class DependencyInjection
	{
		public static IServiceCollection AddPersistance(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("Default");

			services.AddDbContext<ApplicationDbContext>(options => options
					.UseNpgsql(connectionString, b => b.MigrationsAssembly("Presentation")));

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ITvShowRepository, TvShowRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
			services.AddScoped<IUserEpisodeRepository, UserEpisodeRepository>();

            return services;
			
		}

	}
}


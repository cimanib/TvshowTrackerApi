using Domain.UserEpisodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class UserEpisodeConfigurations : IEntityTypeConfiguration<UserEpisode>
    {
        public void Configure(EntityTypeBuilder<UserEpisode> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

        }
    }
}


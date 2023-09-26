using Domain.TvShow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class TvShowConfigurations : IEntityTypeConfiguration<TvShow>
	{
	

        public void Configure(EntityTypeBuilder<TvShow> builder)
        {
            builder.Property(o => o.TvShowId).ValueGeneratedOnAdd();

        }
    }
}


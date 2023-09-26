using Domain.Abstractions;
using Persistance;
 
namespace Infrastructure
{
    public class UnitOfWork: IUnitOfWork
	{

		private readonly ApplicationDbContext applicationDbContext;

		public UnitOfWork(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public async Task SaveChanges(CancellationToken cancellation =default)
		{
			await applicationDbContext.SaveChangesAsync(cancellation);
		}
	}
}


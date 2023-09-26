namespace Domain.Abstractions
{
    public interface IUnitOfWork
	{
        Task SaveChanges(CancellationToken cancellation = default);

    }
}


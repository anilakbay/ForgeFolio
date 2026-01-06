namespace ForgeFolio.Core.Interfaces;

/// <summary>
/// Unit of Work pattern interface for managing transactions
/// </summary>
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

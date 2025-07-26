using UpskillingTask.Domain.Models;

namespace UpskillingTask.Domain.Contracts
{
    public interface IUnitofWork
    {
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompleteAsync();
    }
}
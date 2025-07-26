using System.Collections;
using UpskillingTask.Domain.Contracts;
using UpskillingTask.Domain.Models;
using UpskillingTask.Persistence.Data;

namespace UpskillingTask.Persistence.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly UpskillingTaskDbContext _dbContext;
        private Hashtable _repositories;

        public UnitofWork(UpskillingTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // at start the _repositories is null so
            if (_repositories is null)
            {
                _repositories = new Hashtable();
            }

            var entityKey = typeof(TEntity).Name; //  AS String =>    ex -> "Book"

            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<,>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _dbContext);

                _repositories.Add(entityKey, repositoryInstance);
            }

            return (IGenericRepository<TEntity, TKey>)_repositories[entityKey]!;
        }

        public async Task<int> CompleteAsync()
            => await _dbContext.SaveChangesAsync();
    }
}

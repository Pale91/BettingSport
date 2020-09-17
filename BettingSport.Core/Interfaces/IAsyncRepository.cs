using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.Core.Interfaces
{
    public interface IAsyncRepository<TEntity, TKey> : IAsyncReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey key);

        Task DeleteAsync(TEntity entity);
    }
}

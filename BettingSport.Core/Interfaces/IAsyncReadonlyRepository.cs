using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.Core.Interfaces
{
    public interface IAsyncReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetAsync(TKey key);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

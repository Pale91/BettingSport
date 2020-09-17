using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.Core.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity: BaseEntity
    {

        Task<TEntity> GetAsync(int key);

        Task<IEnumerable<TEntity>> GetAllAsync();
        
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(int key);

        Task DeleteAsync(TEntity entity);
    }
}

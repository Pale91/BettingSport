using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.Core.Interfaces
{
    public interface IAsyncReadonlyRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(int key);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

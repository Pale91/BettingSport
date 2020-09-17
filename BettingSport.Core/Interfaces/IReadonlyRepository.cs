using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.Core.Interfaces
{
    public interface IReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        TEntity Get(TKey key);

        IEnumerable<TEntity> GetAll();
    }
}

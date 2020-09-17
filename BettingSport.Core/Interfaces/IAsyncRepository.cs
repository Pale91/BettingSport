using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.Core.Interfaces
{
    public interface IAsyncRepository<TEntity, TKey> : IAsyncReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TKey key);

        void Delete(TEntity entity);
    }
}

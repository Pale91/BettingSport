using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(int key);

        IEnumerable<TEntity> GetAll();

        TEntity Add(TEntity entity);
        
        TEntity Update(TEntity entity);

        void Delete(int key);

        void Delete(TEntity entity);
    }
}

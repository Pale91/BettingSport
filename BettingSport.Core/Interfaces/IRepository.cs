using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        
        void Update(TEntity entity);

        void Delete(int key);

        void Delete(TEntity entity);
    }
}

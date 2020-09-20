using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.Core.Interfaces
{
    public interface IReadonlyRepository<TEntity> where TEntity: BaseEntity
    {
        TEntity Get(int key);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(ISpecification<TEntity> specification);

    }
}

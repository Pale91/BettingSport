using BettingSport.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BettingSport.Core.Interfaces
{
    public interface ISpecification<TEntity> where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>> Criteria { get; }

        int PageSize { get; }

        /// <summary>
        /// Number of the page on base 1
        /// </summary>
        int PageNumber { get; }

    }
}

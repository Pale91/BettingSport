using BettingSport.API.Helper;
using BettingSport.Core.Entities;
using BettingSport.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BettingSport.API.Specifications
{
    public class PagingSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
    {
        public PagingSpecification(int pageSize = Constants.PAGE_SIZE, int pageNumber = Constants.PAGE_NUMBER)
        {
            PageSize = pageSize < 1 ? Constants.PAGE_SIZE : pageSize;
            PageNumber = pageNumber < 1 ? Constants.PAGE_NUMBER : pageNumber;
            Criteria = _ => true;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; protected set; }

        public int PageSize { get; private set; }

        public int PageNumber { get; private set; }
    }
}

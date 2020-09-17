using BettingSport.Core.Interfaces;
using BettingSport.EfInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BettingSport.EfInfrastructure.AccessData
{
    public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity: class
    {
        BettingSportContext context;
        DbSet<TEntity> dbSet;
        public EfRepository(BettingSportContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public TEntity Get(TKey key)
        {
            return dbSet.Find(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
    }
}

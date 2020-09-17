using BettingSport.Core.Interfaces;
using BettingSport.EfInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.EfInfrastructure.AccessData
{
    public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey>, IAsyncRepository<TEntity, TKey> where TEntity: class
    {
        BettingSportContext context;
        DbSet<TEntity> dbSet;
        public EfRepository(BettingSportContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TKey key)
        {
            return dbSet.Find(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

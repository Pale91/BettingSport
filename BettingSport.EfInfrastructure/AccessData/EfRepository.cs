﻿using BettingSport.Core.Entities;
using BettingSport.Core.Interfaces;
using BettingSport.EfInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.EfInfrastructure.AccessData
{
    public class EfRepository<TEntity> : IRepository<TEntity>, IReadonlyRepository<TEntity>, IAsyncReadonlyRepository<TEntity> where TEntity: BaseEntity
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

        public void Delete(int key)
        {
            var entity = this.Get(key);
            this.dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> specification)
        {
            return ProcessSpecification(specification).ToList();
        }

        public TEntity Get(int key)
        {
            return dbSet.Find(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int key)
        {
            return await this.dbSet.FindAsync(key);
        }

        public void Update(TEntity entity)
        {
            // if entity is a new instance of an attached one with same Id => detach
            var attachedEnity = dbSet.Local.FirstOrDefault(x => x != entity && x.Id == entity.Id);
            if(attachedEnity != null)
            {
                // Deta
                context.Entry(attachedEnity).State = EntityState.Detached;
            }
            this.dbSet.Update(entity);
        }

        public  async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            return await ProcessSpecification(specification).ToListAsync();
        }

        private IQueryable<TEntity> ProcessSpecification(ISpecification <TEntity> specification)
        {
            return dbSet
                .Where(specification.Criteria)
                .Skip((specification.PageNumber - 1) * specification.PageSize)
                .Take(specification.PageSize);
        }
    }
}

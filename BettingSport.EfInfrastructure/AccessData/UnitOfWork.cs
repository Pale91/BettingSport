using BettingSport.Core.Interfaces;
using BettingSport.EfInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.EfInfrastructure.AccessData
{
    public class UnitOfWork : IUnitOfWork, IAsyncUnitOfWork
    {
        BettingSportContext context;
        public UnitOfWork(BettingSportContext context)
        {
            this.context = context;
        }

        public void CommitChanges()
        {
            this.context.SaveChanges();
        }

        public async Task CommitChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}

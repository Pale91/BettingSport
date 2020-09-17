using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BettingSport.Core.Interfaces
{
    public interface IAsyncUnitOfWork
    {
        Task CommitChangesAsync();
    }
}

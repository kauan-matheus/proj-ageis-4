using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementService.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
    }
}
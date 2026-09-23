using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementService.Domain.Entities;

namespace WarehouseManagementService.Domain.Interfaces
{
    public interface IOrderRepository : IRepository
    {
        IQueryable<TaskModel> ConsultarTasks(Guid id);
    }
}
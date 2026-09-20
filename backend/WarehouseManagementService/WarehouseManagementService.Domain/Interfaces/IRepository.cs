using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementService.Domain.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> Consultar<T>() where T : class;
        Task<T?> ConsultarPorId<T>(Guid id) where T : class;
        Task<bool> Cadastrar<T>(T model) where T : class;
        bool Editar<T>(T model) where T : class;
        bool Excluir<T>(T model) where T : class;
    }
}
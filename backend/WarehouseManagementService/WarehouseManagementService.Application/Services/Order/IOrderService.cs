using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementService.Communication.Dto.Requests;
using WarehouseManagementService.Communication.Dto.Responses;
using WarehouseManagementService.Domain.Entities;

namespace WarehouseManagementService.Application.Services.Order
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<OrderModel>>> Consultar();
        Task<ServiceResponse<OrderModel>> ConsultarPorId(Guid id);
        Task<ServiceResponse<List<ResponseTaskDto>>> ConsultarTasks(Guid id);
        Task<ServiceResponse<OrderModel>> Cadastrar(RequestOrderDto orderDto);
        Task<ServiceResponse<OrderModel>> Deletar(Guid id);
    }
}
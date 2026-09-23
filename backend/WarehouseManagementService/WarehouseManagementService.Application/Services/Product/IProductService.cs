using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementService.Communication.Dto.Requests;
using WarehouseManagementService.Communication.Dto.Responses;
using WarehouseManagementService.Domain.Entities;

namespace WarehouseManagementService.Application.Services.Product
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductModel>>> Consultar();
        Task<ServiceResponse<ProductModel>> ConsultarPorId(Guid id);
        Task<ServiceResponse<ProductModel>> Cadastrar(RequestProductDto productDto);
        Task<ServiceResponse<ProductModel>> Deletar(Guid id);
    }
}
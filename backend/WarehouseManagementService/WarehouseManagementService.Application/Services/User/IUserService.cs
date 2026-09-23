using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementService.Communication.Dto.Requests;
using WarehouseManagementService.Communication.Dto.Responses;
using WarehouseManagementService.Domain.Entities;

namespace WarehouseManagementService.Application.Services.User
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserModel>>> Consultar();
        Task<ServiceResponse<UserModel>> ConsultarPorId(Guid id);
        Task<ServiceResponse<UserModel>> Cadastrar(RequestUserDto userDto);
        Task<ServiceResponse<UserModel>> Deletar(Guid id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementService.Communication.Dto.Requests;
using WarehouseManagementService.Communication.Dto.Responses;
using WarehouseManagementService.Domain.Entities;
using WarehouseManagementService.Domain.Interfaces;

namespace WarehouseManagementService.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unit;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unit = unitOfWork;
        }

        public async Task<ServiceResponse<List<UserModel>>> Consultar()
        {
            try
            {
                var query = _repository.Consultar<UserModel>();

                var users = await query.ToListAsync();

                return ServiceResponse<List<UserModel>>.Ok(users);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<UserModel>>.Error(ex.Message);
            }
        }

        public async Task<ServiceResponse<UserModel>> ConsultarPorId(Guid id)
        {
            try
            {
                var result =  await _repository.ConsultarPorId<UserModel>(id);

                if (result == null)
                {
                    return ServiceResponse<UserModel>.BadRequest("Usuario nao existe");
                }

                return ServiceResponse<UserModel>.Ok(result);
            }
            catch (Exception ex)
            {
                return ServiceResponse<UserModel>.Error(ex.Message);
            }
        }
        public async Task<ServiceResponse<UserModel>> Cadastrar(RequestUserDto user)
        {
            await _unit.BeginTransaction();

            try
            {
                var novo = new UserModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Type = user.Type
                };

                await _repository.Cadastrar(novo);
                
                await _unit.Commit();
                await _unit.CommitTransaction();

                return ServiceResponse<UserModel>.Ok(novo);
            }
            catch (Exception ex)
            {
                await _unit.RollbackTransaction();
                return ServiceResponse<UserModel>.Error(ex.Message);
            }
        }

        public async Task<ServiceResponse<UserModel>> Deletar(Guid id)
        {

            try
            {
                var existente = await _repository.ConsultarPorId<UserModel>(id);

                if (existente == null)
                {
                    return ServiceResponse<UserModel>.BadRequest("Usuario nao existe");
                }

                _repository.Excluir(existente);
                var saved = await _unit.Commit();

                if (saved)
                {
                    return ServiceResponse<UserModel>.Ok(existente);
                }

                return ServiceResponse<UserModel>.Error("Nao foi possivel deletar esse pedido");
            }
            catch (Exception ex)
            {
                return ServiceResponse<UserModel>.Error(ex.Message);
            }
        }
    }
}
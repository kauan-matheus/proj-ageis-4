using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementService.Communication.Dto.Requests;
using WarehouseManagementService.Communication.Dto.Responses;
using WarehouseManagementService.Domain.Entities;
using WarehouseManagementService.Domain.Interfaces;

namespace WarehouseManagementService.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unit;

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unit = unitOfWork;
        }

        public async Task<ServiceResponse<List<ProductModel>>> Consultar()
        {
            try
            {
                var query = _repository.Consultar<ProductModel>();

                var users = await query.ToListAsync();

                return ServiceResponse<List<ProductModel>>.Ok(users);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProductModel>>.Error(ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductModel>> ConsultarPorId(Guid id)
        {
            try
            {
                var result =  await _repository.ConsultarPorId<ProductModel>(id);

                if (result == null)
                {
                    return ServiceResponse<ProductModel>.BadRequest("Produto nao existe");
                }

                return ServiceResponse<ProductModel>.Ok(result);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProductModel>.Error(ex.Message);
            }
        }
        public async Task<ServiceResponse<ProductModel>> Cadastrar(RequestProductDto product)
        {
            await _unit.BeginTransaction();

            try
            {
                var novo = new ProductModel
                {
                    Name = product.Name
                };

                await _repository.Cadastrar(novo);
                
                await _unit.Commit();
                await _unit.CommitTransaction();

                return ServiceResponse<ProductModel>.Ok(novo);
            }
            catch (Exception ex)
            {
                await _unit.RollbackTransaction();
                return ServiceResponse<ProductModel>.Error(ex.Message);
            }
        }

        public async Task<ServiceResponse<ProductModel>> Deletar(Guid id)
        {

            try
            {
                var existente = await _repository.ConsultarPorId<ProductModel>(id);

                if (existente == null)
                {
                    return ServiceResponse<ProductModel>.BadRequest("Usuario nao existe");
                }

                _repository.Excluir(existente);
                var saved = await _unit.Commit();

                if (saved)
                {
                    return ServiceResponse<ProductModel>.Ok(existente);
                }

                return ServiceResponse<ProductModel>.Error("Nao foi possivel deletar esse pedido");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProductModel>.Error(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using WarehouseManagementService.Domain.Interfaces;
using WarehouseManagementService.Infra.Data.Data;

namespace WarehouseManagementService.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task CommitTransaction()
        {
            if (_transaction is null)
                throw new Exception("Nenhuma transação ativa");

            await _transaction.CommitAsync();
        }

        public async Task RollbackTransaction()
        {
            if (_transaction is null)
                return;

            await _transaction.RollbackAsync();
        }
    }
}
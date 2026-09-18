using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementService.Domain.Entities
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
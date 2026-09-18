using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementService.Communication.Enums;

namespace WarehouseManagementService.Domain.Entities
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public StatusEnum Status { get; set; }
    }
}
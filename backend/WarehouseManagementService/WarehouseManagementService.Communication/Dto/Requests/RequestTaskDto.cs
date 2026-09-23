using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementService.Communication.Enums;

namespace WarehouseManagementService.Communication.Dto.Requests
{
    public class RequestTaskDto
    {
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
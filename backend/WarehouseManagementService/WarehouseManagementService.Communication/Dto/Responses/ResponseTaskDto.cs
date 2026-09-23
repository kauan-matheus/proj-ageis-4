using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementService.Communication.Enums;

namespace WarehouseManagementService.Communication.Dto.Responses
{
    public class ResponseTaskDto
    {
        public string Description { get; set; } = string.Empty;
        public StatusEnum Status { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathFinderService.Domain.Entities
{
    public class WallModel
    {
        public Guid Id { get; set; }
        public (int, int) Position { get; set; }
    }
}
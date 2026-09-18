using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PathFinderService.Communication.Enums;

namespace PathFinderService.Domain.Classes
{
    public class TileClass
    {
        public (int, int) Position { get; set; }
        public TileTypeEnum Type { get; set; }
    }
}
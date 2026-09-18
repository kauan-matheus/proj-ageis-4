using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PathFinderService.Communication.Enums;

namespace PathFinderService.Domain.Entities
{
    public class ShelfModel
    {
        public Guid Id { get; set; }
        public (int, int) Position { get; set; }
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
        public AccessibilityEnum Accessibility { get; set; }
    }
}
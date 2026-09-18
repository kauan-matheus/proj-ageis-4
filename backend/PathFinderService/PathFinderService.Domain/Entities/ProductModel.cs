using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PathFinderService.Communication.Enums;

namespace PathFinderService.Domain.Entities
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public float UnitWeight { get; set; }
        public float UnitVolume { get; set; }
        public AccessibilityEnum Accessibility { get; set; }
    }
}
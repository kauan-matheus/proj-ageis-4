using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathFinderService.Domain.Entities
{
    public class ProductShelfModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public ProductModel Product { get; set; } = null!;
        public Guid ShelfId { get; set; }
        public ShelfModel Shelf { get; set; } = null!;
    }
}
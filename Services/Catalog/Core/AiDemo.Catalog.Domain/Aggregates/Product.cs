using AiDemo.Catalog.Domain.Events.Product;
using AiDemo.SharedLiblary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Domain.Aggregates
{
    public class Product : AggregateRoot<Guid>
    {
        public Product(){}
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public int? CategoryId { get; private set; }
        public Category? Category { get; private set; }
        public string? ImageUrl { get; private set; } = "noimage.png";
        public Product(string name, string description, decimal price, int stock,int? categoryId = null )
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }
        public void UpdateStock(int quantity)
        {
            if (quantity < 0 && Math.Abs(quantity) > Stock)
                throw new InvalidOperationException("Insufficient stock to reduce.");
            var oldStock = Stock;
            Stock += quantity;
            AddDomainEvent(new ProductStockUpdatedEvent(Id, Stock,oldStock));
        }
    }
}

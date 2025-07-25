using AiDemo.SharedLiblary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Domain.Events.Product
{
    public class ProductStockUpdatedEvent : DomainEvent
    {
        public Guid ProductId { get; private set; }
        public int NewStock { get; private set; }
        public int OldStock { get; private set; }
        public ProductStockUpdatedEvent(Guid productId, int newStock,int oldStock)
        {
            ProductId = productId;
            OldStock = oldStock;
            NewStock = newStock;
        }
        public override string ToString()
        {
            return $"ProductStockUpdatedEvent: ProductId={ProductId}, Stock={NewStock}";
        }
    }
}

﻿using EventBus;
using System.Threading.Tasks;

namespace Product.Api.IntegrationEvents
{
    public class ProductPriceChangedIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; private init; }

        public decimal NewPrice { get; private init; }

        public decimal OldPrice { get; private init; }

        public ProductPriceChangedIntegrationEvent(int productId, decimal newPrice, decimal oldPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
            OldPrice = oldPrice;
        }
    }

    public class ProductPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ProductPriceChangedIntegrationEvent>
    {
        public Task Handle(ProductPriceChangedIntegrationEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
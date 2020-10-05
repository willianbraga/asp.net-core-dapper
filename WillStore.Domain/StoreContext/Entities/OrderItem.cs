using System;
using System.Collections;
using System.Collections.Generic;
using FluentValidator;

namespace WillStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

        public OrderItem(Product product, decimal quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantidade", "Produto fora de estoque");

            product.RemoveQuantity(quantity);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using WillStore.Domain.StoreContext.Enums;
using WillStore.Shared.Entities;

namespace WillStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
        public Order(Customer customer)
        {
            this.Customer = customer;
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            this._items = new List<OrderItem>();
            this._deliveries = new List<Delivery>();
        }
        public void Place()
        {
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");
        }
        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }
        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            var deliveries = new List<Delivery>();
            var count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x => _deliveries.Add(x));
        }
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}
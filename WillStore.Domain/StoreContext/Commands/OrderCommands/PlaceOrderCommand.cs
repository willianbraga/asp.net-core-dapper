using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using WillStore.Shared.Commands;

namespace WillStore.Domain.StoreContext.Commands.OrderCommands
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public Guid CustomerId { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public bool IsValid()
        {
            AddNotifications(
                new ValidationContract()
                    .HasLen(CustomerId.ToString(), 36, "Customer", "Identificador do cliente inválido.")
                    .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
            );
            return base.Valid;
        }
    }

    public class OrderItemCommand
    {
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
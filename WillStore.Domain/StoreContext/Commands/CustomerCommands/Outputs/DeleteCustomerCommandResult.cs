using System;
using FluentValidator;
using WillStore.Shared.Commands;

namespace WillStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class DeleteCustomerCommandResult : Notifiable, ICommandResult
    {
        public DeleteCustomerCommandResult()
        { }
        public DeleteCustomerCommandResult(Guid customerId)
        {
            CustomerId = customerId;
        }
        public Guid CustomerId { get; set; }
    }
}
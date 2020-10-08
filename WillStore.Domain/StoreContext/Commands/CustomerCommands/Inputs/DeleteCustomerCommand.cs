using System;
using FluentValidator;
using FluentValidator.Validation;
using WillStore.Shared.Commands;

namespace WillStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class DeleteCustomerCommand : Notifiable, ICommand
    {
        public DeleteCustomerCommand()
        { }
        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
        public Guid CustomerId { get; set; }
        public bool IsValid()
        {
            return true;
        }
    }
}
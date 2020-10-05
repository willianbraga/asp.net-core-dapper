using System;
using FluentValidator;
using WillStore.Shared.Commands;

namespace WillStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : Notifiable, ICommandResult
    {
        public CreateCustomerCommandResult()
        { }
        public CreateCustomerCommandResult(Guid customerId, string name, string email)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
        }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
using System;
using FluentValidator;
using WillStore.Shared.Commands;

namespace WillStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class EditCustomerCommandResult : Notifiable, ICommandResult
    {
        public EditCustomerCommandResult()
        { }
        public EditCustomerCommandResult(Guid customerId, string name, string email, string document, string phone)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            Document = document;
            Phone = phone;
        }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
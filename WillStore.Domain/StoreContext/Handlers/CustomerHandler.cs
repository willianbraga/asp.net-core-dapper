using System;
using FluentValidator;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.ValueObjects;
using WillStore.Shared.Commands;

namespace WillStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
                    Notifiable,
                    ICommandHandler<CreateCustomerCommand>,
                    ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name);
            AddNotifications(document);
            AddNotifications(email);
            AddNotifications(customer);

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
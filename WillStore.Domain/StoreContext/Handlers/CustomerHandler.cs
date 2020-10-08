using System;
using FluentValidator;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.Repositories;
using WillStore.Domain.StoreContext.Services;
using WillStore.Domain.StoreContext.ValueObjects;
using WillStore.Shared.Commands;

namespace WillStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
                    Notifiable,
                    ICommandHandler<CreateCustomerCommand>,
                    ICommandHandler<AddAddressCommand>,
                    ICommandHandler<EditCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name);
            AddNotifications(document);
            AddNotifications(email);
            AddNotifications(customer);

            if (Invalid)
                return null;

            _repository.Save(customer);

            _emailService.Send(email.Address, "willian.kaeru@gmail.com", "Bem vindo", "Seja bem vindo, Compre conosco");

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(EditCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name);
            AddNotifications(document);
            AddNotifications(email);
            AddNotifications(customer);

            if (Invalid)
                return null;

            _repository.Edit(customer);

            _emailService.Send(email.Address, "willian.kaeru@gmail.com", "Customer editado", customer.Name.ToString());

            return new EditCustomerCommandResult(customer.Id, name.ToString(), email.Address, customer.Document.ToString(), customer.Phone);
        }
        public ICommandResult Handle(DeleteCustomerCommand command)
        {
            var customer = _repository.GetCustomerById(command.CustomerId);
            if (customer == null)
                AddNotification("Customer", "CustomerId informado não foi encontrado na base.");

            if (Invalid)
                return null;

            _repository.Delete(customer.Id);

            _emailService.Send(customer.Email, "willian.kaeru@gmail.com", "Customer Excluido", customer.Name.ToString());

            return new DeleteCustomerCommandResult(customer.Id);

        }
    }
}
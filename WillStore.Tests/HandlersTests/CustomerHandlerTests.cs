using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using WillStore.Domain.StoreContext.Handlers;
using WillStore.Tests.Mocks;

namespace WillStore.Tests.HandlersTests
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void Should_register_when_command_valid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Willian";
            command.LastName = "Braga";
            command.Document = "35350803808";
            command.Email = "Willian.kaeru@gmail.com";
            command.Phone = "11979942801";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}
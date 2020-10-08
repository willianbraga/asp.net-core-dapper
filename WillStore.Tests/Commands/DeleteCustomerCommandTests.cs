using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace WillStore.Tests.Commands
{
    [TestClass]
    public class DeleteCustomerCommandTests
    {
        [TestMethod]
        public void Should_validate_when_command_is_valid()
        {
            var command = new DeleteCustomerCommand();
            command.CustomerId = Guid.NewGuid();

            Assert.AreEqual(true, command.IsValid());
        }
    }
}
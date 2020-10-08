using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace WillStore.Tests.Commands
{
    [TestClass]
    public class EditCustomerCommandTests
    {
        [TestMethod]
        public void Should_validate_when_command_is_valid()
        {
            var command = new EditCustomerCommand();
            command.FirstName = "Willian";
            command.LastName = "Braga";
            command.Document = "35350803808";
            command.Email = "Willian.kaeru@gmail.com";
            command.Phone = "11979942801";

            Assert.AreEqual(true, command.IsValid());
        }
    }
}
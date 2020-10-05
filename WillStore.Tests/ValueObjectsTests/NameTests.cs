using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.ValueObjects;

namespace WillStore.Tests.ValueObjectsTests
{
    [TestClass]
    public class NameTests
    {
        private Name _validName;
        private Name _invalidName;

        public NameTests()
        {
            _validName = new Name("Willian", "Braga");
            _invalidName = new Name("e", "e");
        }
        [TestMethod]
        public void Should_return_notification_when_name_invalid()
        {
            Assert.AreNotEqual(0, _invalidName.Notifications.Count);
        }
        [TestMethod]
        public void Should_not_return_notification_when_name_valid()
        {
            Assert.AreEqual(0, _validName.Notifications.Count);
        }
    }
}
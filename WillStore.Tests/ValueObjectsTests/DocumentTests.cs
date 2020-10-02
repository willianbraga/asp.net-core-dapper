using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.ValueObjects;

namespace WillStore.Tests.ValueObjectsTests
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("35350803808");
            invalidDocument = new Document("3535080380");
        }
        [TestMethod]
        public void Should_not_return_notification_when_documment_valid()
        {
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
        [TestMethod]
        public void Should_return_notification_when_documment_invalid()
        {
            Assert.AreNotEqual(0, invalidDocument.Notifications.Count);
        }
    }
}
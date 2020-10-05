using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.ValueObjects;

namespace WillStore.Tests.ValueObjectsTests
{
    [TestClass]
    public class EmailTests
    {
        private Email _validEmail;
        private Email _invalidEmail;
        public EmailTests()
        {
            _validEmail = new Email("willian.kaeru.com");
            _invalidEmail = new Email("willian.kaeru@gmail.com");
        }
        [TestMethod]
        public void Shoud_return_notification_when_email_invalid()
        {
            Assert.AreEqual(false, _validEmail.Valid);
        }
        [TestMethod]
        public void Shoud_return_not_notification_when_email_valid()
        {
            Assert.AreEqual(true, _invalidEmail.Valid);

        }
    }
}
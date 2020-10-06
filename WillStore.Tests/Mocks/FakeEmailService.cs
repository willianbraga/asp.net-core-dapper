using WillStore.Domain.StoreContext.Services;

namespace WillStore.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {

        }
    }
}
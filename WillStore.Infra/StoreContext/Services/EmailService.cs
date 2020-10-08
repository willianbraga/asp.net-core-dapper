using WillStore.Domain.StoreContext.Services;

namespace WillStore.Infra.StoreContext.Services
{
    public class EmailService : IEmailService   
    {
        public void Send(string to, string from, string subject, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}
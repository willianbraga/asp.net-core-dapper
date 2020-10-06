using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.Repositories;

namespace WillStore.Tests.Mocks
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {

        }
    }
}
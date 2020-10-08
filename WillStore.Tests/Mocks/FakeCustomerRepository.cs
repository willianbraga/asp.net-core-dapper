using System;
using System.Collections.Generic;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.Queries;
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

        public void Delete(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer customer)
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerQueryResult> GetCustomerList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetCustomerOrder(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {

        }
    }
}
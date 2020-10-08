using System;
using System.Collections.Generic;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.Queries;

namespace WillStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        IEnumerable<ListCustomerQueryResult> GetCustomerList();
        GetCustomerQueryResult GetCustomerById(Guid customerId);
        IEnumerable<ListCustomerOrderQueryResult> GetCustomerOrder(Guid customerId);
        void Edit(Customer customer);
        void Delete(Guid customerId);
    }
}
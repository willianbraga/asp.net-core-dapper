using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.Queries;
using WillStore.Domain.StoreContext.Repositories;
using WillStore.Infra.StoreContext.DataContexts;

namespace WillStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly WillDataContext _context;

        public CustomerRepository(WillDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return _context
                        .Connection
                        .Query<bool>(
                            "spCheckDocument",
                            new { Document = document },
                            commandType: CommandType.StoredProcedure)
                        .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                        .Connection
                        .Query<bool>(
                            "spCheckEmail",
                            new { Email = email },
                            commandType: CommandType.StoredProcedure)
                        .FirstOrDefault();
        }

        public GetCustomerQueryResult GetCustomerById(Guid customerId)
        {
            return _context
                        .Connection
                        .Query<GetCustomerQueryResult>(
                            "spGetCustomerById"
                            , new { id = customerId })
                        .FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> GetCustomerList()
        {
            return _context
                        .Connection
                        .Query<ListCustomerQueryResult>(
                            "spGetAllCustomers");
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetCustomerOrder(Guid customerId)
        {
            return _context
                        .Connection
                        .Query<ListCustomerOrderQueryResult>(
                            "spSelectCustomerOrder", new { id = customerId });
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type
                    }, commandType: CommandType.StoredProcedure);
            }
        }
        public void Edit(Customer customer)
        {
            _context.Connection.Execute("spUpdateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);
        }

        public void Delete(Guid customerId)
        {
            _context.Connection.Execute("spDeleteCustomer",
                new
                {
                    Id = customerId
                });
        }
    }
}
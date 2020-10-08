using System;
namespace WillStore.Domain.StoreContext.Queries
{
    public class ListCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Docunent { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
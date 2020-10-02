using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.ValueObjects;

namespace WillStore.Tests.EntityTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void teste()
        {
            var name = new Name("Willian", "Braga");
            var document = new Document("123456789");
            var email = new Email("willian.kaeru@gmail.com");
            var customer = new Customer(name, document, email, "11321123123");

            var mouse = new Product("Mouse", "Rato", "image.jpg", 20.99M, 10);
            var teclado = new Product("Teclado", "Teclado", "image1.jpg", 30.99M, 10);
            var monitor = new Product("Monitor", "Monitor", "image2.jpg", 900.99M, 10);
            var cpu = new Product("Cpu", "Cpu", "image3.jpg", 2220.99M, 10);

            var order = new Order(customer);

            // order.AddItem(new OrderItem(mouse, 1));
            // order.AddItem(new OrderItem(teclado, 1));
            // order.AddItem(new OrderItem(monitor, 1));
            // order.AddItem(new OrderItem(cpu, 1));

            order.Place();

            var valid = order.Valid;

            order.Pay();

            order.Ship();

            order.Cancel();

        }
    }
}
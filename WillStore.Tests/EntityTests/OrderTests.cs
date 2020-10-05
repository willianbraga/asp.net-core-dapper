using Microsoft.VisualStudio.TestTools.UnitTesting;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.Enums;
using WillStore.Domain.StoreContext.ValueObjects;

namespace WillStore.Tests.EntityTests
{
    [TestClass]
    public class OrderTests
    {
        private Name _name;
        private Document _document;
        private Email _email;
        private Customer _customer;
        private const string PHONE = "11979942801";
        private Order _validOrder;
        private Product _mouse;
        private Product _keyboard;
        private Product _monitor;
        private Product _cpu;


        public OrderTests()
        {
            _name = new Name("Willian", "Braga");
            _document = new Document("35350803808");
            _email = new Email("willian.kaeru@gmail.com");
            _customer = new Customer(_name, _document, _email, PHONE);
            _validOrder = new Order(_customer);
            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 50M, 2);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "teclado.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 500M, 10);
            _cpu = new Product("CPU Gamer", "CPU Gamer", "cpu.jpg", 5000M, 10);
        }
        [TestMethod]
        public void Should_create_order_when_valid()
        {
            Assert.AreEqual(true, _validOrder.Valid);
        }
        [TestMethod]
        public void Status_should_be_created_when_new_valid_order()
        {
            Assert.AreEqual(EOrderStatus.Created, _validOrder.Status);
        }
        [TestMethod]
        public void Should_return_two_when_added_2_valid_items()
        {
            _validOrder.AddItem(_mouse, 2);
            _validOrder.AddItem(_keyboard, 1);
            Assert.AreEqual(2, _validOrder.Items.Count);
        }
        [TestMethod]
        public void Should_return_zero_when_added_purchased_2_valid_items()
        {
            _validOrder.AddItem(_mouse, 2);
            Assert.AreEqual(_mouse.QuantityOnHand, 0);
        }
        [TestMethod]
        public void Should_return_number_when_order_placed()
        {
            _validOrder.Place();
            Assert.AreNotEqual("", _validOrder.Number);
        }
        [TestMethod]
        public void Status_should_return_paid_when_order_paid()
        {
            _validOrder.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _validOrder.Status);
        }
        [TestMethod]
        public void Should_return_two_deliveries_when_purchased_ten_products()
        {
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.Place();
            _validOrder.Pay();
            _validOrder.Ship();
            Assert.AreEqual(2, _validOrder.Deliveries.Count);
        }
        [TestMethod]
        public void Status_should_return_canceled_when_order_canceled()
        {
            _validOrder.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _validOrder.Status);
        }
        [TestMethod]
        public void Should_cancel_shipping_when_order_canceled()
        {
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.AddItem(_cpu, 1);
            _validOrder.Place();
            _validOrder.Pay();
            _validOrder.Ship();
            _validOrder.Cancel();

            foreach (var x in _validOrder.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}
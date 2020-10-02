using FluentValidator;

namespace WillStore.Domain.StoreContext.Entities
{
    public class Product : Notifiable
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }

        public Product(string title, string description, string image, decimal price, decimal quantity)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;
            this.QuantityOnHand = quantity;
        }
        public override string ToString()
        {
            return this.Title;
        }

    }
}
using FluentValidator;
using FluentValidator.Validation;

namespace WillStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            this.Address = address;

            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .IsEmail(Address, "Email", "O email informado é invalido.")
                );
        }
        public override string ToString()
        {
            return Address;
        }
    }
}
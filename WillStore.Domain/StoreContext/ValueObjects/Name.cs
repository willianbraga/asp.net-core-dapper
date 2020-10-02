using FluentValidator;
using FluentValidator.Validation;

namespace WillStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .HasMinLen(FirstName, 2, "FirstName", "O nome deve conter pelo menos 2 caracteres.")
                    .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no max 40 caracteres.")
                    .HasMinLen(LastName, 2, "LastName", "O sobrenome deve conter pelo menos 2 caracteres.")
                    .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no max 40 caracteres.")
                    );


        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
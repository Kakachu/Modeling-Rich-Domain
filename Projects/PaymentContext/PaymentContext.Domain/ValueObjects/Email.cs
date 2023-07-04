using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
	public class Email : ValueObject
	{
		public Email(string address)
		{
			Address = address;

			AddNotifications(new Contract<Notification>()
				.Requires()
				.IsEmail(address, "Email.Address", "Invalid E-mail"));
		}

		public string Address { get; set; }
	}
}

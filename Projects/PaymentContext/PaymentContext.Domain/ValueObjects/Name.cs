using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
	public class Name : ValueObject
	{
		public Name(string firstName, string lastName)
		{
			AddNotifications(new Contract<Notification>()
				.Requires()
				.IsGreaterThan(firstName, 3, "FirstName", "Name should have at least 3 chars")
				.IsGreaterThan(lastName, 3, "LastName", "Last name should have at least 3 chars")
				.IsLowerThan(firstName, 40, "FirstName", "Name should have no more than 40 chars")
				.IsLowerThan(lastName, 40, "LastName", "Last name should have no more than 40 chars")
			);

			if (IsValid)
			{
				FirstName = firstName;
				LastName = lastName;
			}
		}

		public string FirstName { get; private set; }

		public string LastName { get; private set; }
	}
}

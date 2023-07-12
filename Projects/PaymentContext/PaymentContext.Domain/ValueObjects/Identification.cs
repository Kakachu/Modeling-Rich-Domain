using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enum;
using PaymentContext.Shared.ValueObjects;
using System.Diagnostics.Contracts;

namespace PaymentContext.Domain.ValueObjects
{
	public class Identification : ValueObject
	{
		public Identification(string number, EIdentificationType type)
		{
			if (IsValid)
			{
				Number = number;
				Type = type;
			}

			AddNotifications(new Contract<Notification>()
				.Requires()
				.IsTrue(Validate(), "Identification.Number", "Invalid document")
			);
		}

		public string Number { get; private set; }

		public EIdentificationType Type { get; set; }

		private bool Validate()
		{
			if (Type == EIdentificationType.CNPJ && Number.Length == 14)
				return true;

			if (Type == EIdentificationType.CPF && Number.Length == 11)
				return true;

			return false;
		}
	}
}

using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Diagnostics.Contracts;

namespace PaymentContext.Domain.Entities
{
	public abstract class Payment : Entity
	{
		protected Payment(Identification identification, Email email, Address address, DateTime datePaid, DateTime dateExpiration, decimal total, decimal totalPaid)
		{
			Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
			Identification = identification;
			Email = email;
			Address = address;
			DatePaid = datePaid;
			DateExpiration = dateExpiration;
			Total = total;
			TotalPaid = totalPaid;

			AddNotifications(new Contract<Notification>()
				.Requires()
				.IsGreaterThan(0, Total, "Payment.Total", "Cannot be zero")
				.IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "The amount paid is less than payment costs.")
				);
		}

		public string Number { get; private set; }

		public Identification Identification { get; private set; }

		public Email Email { get; private set; }

		public Address Address { get; private set; }

        public DateTime DatePaid { get; private set; }

        public DateTime DateExpiration { get; private set; }

        public decimal Total { get; private set; }

        public decimal TotalPaid { get; private set; }
    }
}

using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Entities;
using System.Diagnostics.Contracts;

namespace PaymentContext.Domain.Entities
{
	public class Subscription : Entity
	{
		private IList<Payment> _payments;

		public Subscription(DateTime? dateExpiration, string owner)
		{
			Owner = owner;
			IsEnable = true;
			DateCreated = DateTime.Now;
			DateUpdated = DateTime.Now;
			DateExpiration = dateExpiration;
			_payments = new List<Payment>();
		}

        public string Owner { get; private set; }

        public bool IsEnable { get; private set; }

        public DateTime DateCreated { get; private set; }

		public DateTime DateUpdated { get; private set; }

		public DateTime? DateExpiration { get; private set; }

		public IReadOnlyCollection<Payment> Payments { get; private set; }

		public void AddPayment(Payment payment)
		{
			AddNotifications(new Contract<Notification>()
				.Requires()
				.IsGreaterThan(DateTime.Now, payment.DatePaid, "Subscription.Payments", "Payment date must be in the future.")
			);

			_payments.Add(payment);
		}

		public void Enable()
		{
			IsEnable = true;
			DateUpdated = DateTime.Now;
		}

		public void Disable() 
		{
			IsEnable = false;
			DateCreated = DateTime.Now;
		}
	}
}

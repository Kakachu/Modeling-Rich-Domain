using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Diagnostics.Contracts;

namespace PaymentContext.Domain.Entities
{
	public class Student : Entity
	{
		private IList<Subscription> _subcriptions;
		private IList<Payment> _payments;

		public Student(Name name, Identification identification, Email email)
		{
			Name = name;
			Identification = identification;
			Email = email;
			_subcriptions = new List<Subscription>();
			_payments = new List<Payment>();

			AddNotifications(name, identification, email);
		}

        public Name Name { get; set; }

        public Identification Identification { get; set; }

		public Email Email { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subcriptions.ToArray(); } }

        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

		public void AddSubscription(Subscription subscription)
		{ 
			var hasSubscriptonActive = false;
			foreach(var sub in _subcriptions)
			{
				if(sub.IsEnable)
					hasSubscriptonActive = true;
			}

			AddNotifications(new Contract<Notification>()
				.Requires()
				.IsFalse(hasSubscriptonActive, "Student.Subscription", "You already has a enabled subscription")
				.AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "This subscription doesn't has any payment")
			);
		}
	}
}
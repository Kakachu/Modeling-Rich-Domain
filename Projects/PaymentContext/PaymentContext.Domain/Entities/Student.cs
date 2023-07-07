using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
	public class Student : Entity
	{
		private IList<Subscription> _subcriptions;

		public Student(Name name, Identification identification, Email email, string phoneNumber, Address address)
		{
			Name = name;
			Identification = identification;
			Email = email;
			PhoneNumber = phoneNumber;
			Address = address;
			_subcriptions = new List<Subscription>();

			AddNotifications(name, identification, email, address);
		}

        public Name Name { get; set; }

        public Identification Identification { get; set; }

		public Email Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subcriptions.ToArray(); } }

        public List<Payment> Payments { get; private set; }

		public void RegisterSubscription(Subscription subscription)
		{ 
			var hasSubscriptonActive = false;
			foreach(var sub in _subcriptions)
			{
				if(sub.IsEnable)
					hasSubscriptonActive = true;
			}

			if (hasSubscriptonActive)
				AddNotification("Student.Subscriptions", "You already has a enabled subscription");
		}
	}
}
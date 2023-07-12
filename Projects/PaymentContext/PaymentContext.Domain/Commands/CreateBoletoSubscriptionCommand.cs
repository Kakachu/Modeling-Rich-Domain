using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enum;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
	public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Identification { get; set; }

		public string Email { get; set; }

		public string BoletoNumber { get; set; }

		public string BarCode { get; set; }

		public DateTime DatePaid { get; set; }

		public DateTime DateExpiration { get; set; }

		public decimal Total { get; set; }

		public decimal TotalPaid { get; set; }

		public string Payer { get; set; }

		public string PayerIdentification { get; set; }

		public string PayerEmail { get; set; }

		public EIdentificationType EPayerIdentificationType { get; set; }

		public string Street { get; set; }

		public string Number { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string Country { get; set; }

		public string ZipCode { get; set; }

		public void Validate()
		{
			AddNotifications(new Contract<Notification>()
				.Requires()
				.IsGreaterThan(FirstName, 3, "FirstName", "Name should have at least 3 chars")
				.IsGreaterThan(LastName, 3, "LastName", "Last name should have at least 3 chars")
				.IsLowerThan(FirstName, 40, "FirstName", "Name should have no more than 40 chars")
				.IsLowerThan(LastName, 40, "LastName", "Last name should have no more than 40 chars")
			);
		}
	}
}

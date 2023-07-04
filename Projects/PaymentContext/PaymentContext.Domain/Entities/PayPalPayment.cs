using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
	public class PayPalPayment : Payment
	{
		public PayPalPayment(string transactionCode, Identification identification, Email email, Address address, DateTime datePaid, DateTime dateExpiration, decimal total, decimal totalPaid) : base
							(identification, email, address, datePaid, dateExpiration, total, totalPaid)
		{
			TransactionCode = transactionCode;
		}

		public string TransactionCode { get; private set; }
    }
}

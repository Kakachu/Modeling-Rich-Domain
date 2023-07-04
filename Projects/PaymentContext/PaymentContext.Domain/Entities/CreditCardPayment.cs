using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
	public class CreditCardPayment : Payment
	{
		public CreditCardPayment(string cardOwnerName, string cardLastNumber, string lastTransactionNumber, Identification identification,
			Email email, Address address, DateTime datePaid, DateTime dateExpiration, decimal total, decimal totalPaid) : base
			(identification, email, address, datePaid, dateExpiration, total, totalPaid)
		{
			CardOwnerName = cardOwnerName;
			CardLastNumber = cardLastNumber;
			LastTransactionNumber = lastTransactionNumber;
		}

		public string CardOwnerName { get; private set; }

        public string CardLastNumber { get; private set; }

        public string LastTransactionNumber { get; private set; }
    }
}

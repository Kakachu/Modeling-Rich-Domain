using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
	public class BoletoPayment : Payment
	{
		public BoletoPayment(string boletoNumber, string barCode, Identification identification, Email email, Address address, DateTime datePaid, DateTime dateExpiration, decimal total, decimal totalPaid) : base
							(identification, email, address, datePaid, dateExpiration, total, totalPaid)
		{
			BoletoNumber = boletoNumber;
			BarCode = barCode;
		}

		public string BoletoNumber { get; private set; }

        public string BarCode { get; private set; }
	}
}

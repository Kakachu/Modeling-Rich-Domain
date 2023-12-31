﻿using PaymentContext.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
	public class CreateCreditCardSubscriptionCommand
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Identification { get; set; }

		public string Email { get; set; }

		public string CardOwnerName { get; private set; }

		public string CardLastNumber { get; private set; }

		public string LastTransactionNumber { get; private set; }

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
	}
}

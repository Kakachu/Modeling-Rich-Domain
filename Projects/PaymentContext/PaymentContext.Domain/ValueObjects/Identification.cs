using PaymentContext.Domain.Enum;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
	public class Identification : ValueObject
	{
		public Identification(string number, EIdentificationType type)
		{
			Number = number;
			Type = type;

		}

        public string Number { get; private set; }

        public EIdentificationType Type { get; set; }
    }
}

using PaymentContext.Domain.Enum;

namespace PaymentContext.Domain.ValueObjects
{
	public class Identification
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

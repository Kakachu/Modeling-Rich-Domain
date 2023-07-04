namespace PaymentContext.Domain.ValueObjects
{
	public class Name
	{
		public Name(string fistName, string lastName)
		{
			FistName = fistName;
			LastName = lastName;	
		}

        public string FistName { get; private set; }

        public string LastName { get; private set; }
	}
}

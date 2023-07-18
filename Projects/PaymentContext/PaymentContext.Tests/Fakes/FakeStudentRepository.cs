using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Fakes
{
	public class FakeStudentRepository : IStudentRepository
	{
		public bool EmailExists(string email)
		{
			if(email == "test@live.com")
				return true; 
			
			return false;
		}

		public bool IdentificationExists(string identification)
		{
			if(identification == "99999999999")
				return true;

			return false;
		}

		public void RegisterSubscription(Student student)
		{
		}
	}
}

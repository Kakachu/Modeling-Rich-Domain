using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
	public interface IStudentRepository
	{
		bool IdentificationExists(string identification);

		bool EmailExists(string email);

		void RegisterSubscription(Student student);
    }
}

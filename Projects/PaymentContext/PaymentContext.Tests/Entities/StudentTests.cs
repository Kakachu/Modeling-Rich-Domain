using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
	[TestClass]
	public class StudentTests
	{
		private readonly Student _student;
		private readonly Subscription _subscription;
		private readonly Name _name;
		private readonly Identification _identification;
		private readonly Address _address;
		private readonly Email _email;

        public StudentTests()
        {
			_name = new Name("Arnold", "Schwarzenegger");
			_identification = new Identification("40288093046", EIdentificationType.CPF);
			_email = new Email("arnold.terminator@hotmail.com");
			_student = new Student(_name, _identification, _email);
			_subscription = new Subscription(null, null);
			_address = new Address("Bd Ste Sophie", "2151", "Ste-Sophie", "Quebec", "Canada", "J5J2P6");
		}

        [TestMethod]
		public void ShouldReturnErrorWhenSubscriptionIsEnabled()
		{
			var payment = new PayPalPayment("12345678", _identification, _email, _address, DateTime.Now, DateTime.Now.AddDays(5), 10, 10);

			_subscription.AddPayment(payment);
			_student.AddSubscription(_subscription);
			_student.AddSubscription(_subscription);

			Assert.IsFalse(_student.IsValid);
		}

		[TestMethod]
		public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
		{
			_student.AddSubscription(_subscription);

			Assert.IsFalse(_student.IsValid);
		}

		[TestMethod]
		public void ShouldReturnSuccessWhenSubscriptionIsNotEnabled()
		{
			var payment = new PayPalPayment("12345678", _identification, _email, _address, DateTime.Now, DateTime.Now.AddDays(5), 10, 10);

			_subscription.AddPayment(payment);
			_student.AddSubscription(_subscription);

			Assert.IsFalse(_student.IsValid);
		}
	}
}

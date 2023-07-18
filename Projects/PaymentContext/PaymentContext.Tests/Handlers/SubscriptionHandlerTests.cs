using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Fakes;

namespace PaymentContext.Tests.Handlers
{
	[TestClass]
	public class MyTestClass
	{
		[TestMethod]
		public void ShouldReturnErrorWhenIDentificationExists()
		{
			var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailRepository());
			var command = new CreateBoletoSubscriptionCommand();


			command.FirstName = "Arnold";

			command.LastName = "Schwarzenergger";

			command.Identification = "99999999999";

			command.Email = "test@live.com";

			command.BoletoNumber = "123456789";

			command.BarCode = "12348695789";

			command.DatePaid = DateTime.Now;

			command.DateExpiration = DateTime.Now.AddMonths(1);

			command.Total = 60;

			command.TotalPaid = 60;

			command.Payer = "Muscle Corp";

			command.PayerIdentification = "12345678911";

			command.PayerEmail = "muscle@gmail.com";

			command.EPayerIdentificationType = EIdentificationType.CPF;

			command.EIdentificationType = EIdentificationType.CPF;

			command.Street = "asdd";

			command.Number = "awdf";

			command.City = "awdg";

			command.State = "hgtf";

			command.Country = "aef";

			command.ZipCode = "12345678";

			handler.Handle(command);
			Assert.AreEqual(false, handler.IsValid);
		}
	}
}

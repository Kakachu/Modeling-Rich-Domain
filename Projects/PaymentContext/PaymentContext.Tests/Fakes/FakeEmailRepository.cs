using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Fakes
{
	public class FakeEmailRepository : IEmailService
	{
		void IEmailService.Send(string to, string email, string subject, string body)
		{

		}
	}
}

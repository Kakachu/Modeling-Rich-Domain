using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
	[TestClass]
	public class StudentTests
	{
		[TestMethod]
		public void TestsMethod()
		{
			var name = new Name("FistName", "LastName");
			foreach (var notification in name.Notifications)
			{
				var message = notification.Message;
			}

		}
	}
}

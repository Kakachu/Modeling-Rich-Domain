using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.ValueObjects;
using System.Diagnostics.Contracts;

namespace PaymentContext.Tests.ValueObjects
{
	[TestClass]
    public class IdentificationTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
			var identity = new Identification("123", EIdentificationType.CNPJ);
			Assert.IsFalse(identity.IsValid);
		}

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var identity = new Identification("57022024000169", EIdentificationType.CNPJ);
            Assert.IsTrue(identity.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
			var identity = new Identification("123", EIdentificationType.CPF);
			Assert.IsFalse(identity.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("40288093046")]
        [DataRow("93540298096")]
        [DataRow("47749922083")]
        [DataRow("11606921061")]
		public void ShouldReturnSuccessWhenCPFIsValid(string identification)
        {
            var identity = new Identification(identification, EIdentificationType.CPF);
            Assert.IsTrue(identity.IsValid);
        }
    }
}

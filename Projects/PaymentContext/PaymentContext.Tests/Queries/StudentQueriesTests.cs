using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
	[TestClass]
	public class StudentQueriesTests
	{
		private IList<Student> _students;

        public StudentQueriesTests()
        {
			for (var i = 0; i <= 10; i++)
			{
				_students.Add(new Student(
					new Name("student", i.ToString()),
					new Identification("11111111111" + i.ToString(), EIdentificationType.CPF),
					new Email("student.one@gmail.com")
					));
			}
        }

        [TestMethod]
		public void ShouldReturnNullWhenIdentificationNotExists()
		{
			var expression = StudentQueries.GetStudent("12345678911");
			var student = _students.AsQueryable().Where(expression).FirstOrDefault();

			Assert.AreEqual(null, student);
		}
	}
}

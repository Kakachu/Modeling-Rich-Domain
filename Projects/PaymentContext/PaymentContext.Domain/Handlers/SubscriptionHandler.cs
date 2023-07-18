using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
	public class SubscriptionHandler :
		Notifiable<Notification>,
		IHandler<CreateBoletoSubscriptionCommand>
	{
		private readonly IStudentRepository _studentRepository;
		private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository studentRepository,
								   IEmailService emailService)
        {
			_studentRepository = studentRepository;	
			_emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
		{
			//Fail Fast Validations
			command.Validate();
			if (!command.IsValid)
			{
				AddNotifications(command);
				return new CommandResult(false, "It was not possible to realize your subscription");
			}
			//Verify if identification already exists
			var identificationExists = _studentRepository.IdentificationExists(command.Identification);
			if(identificationExists)
				AddNotification("Email", "Identification already in use");

			//Verify if email already exists
			var emailExists = _studentRepository.EmailExists(command.Email);
			if (emailExists)
				AddNotification("Email", "E-mail already in use");

			//Generate Value Objects
			var name = new Name(command.FirstName, command.LastName);
			var identification = new Identification(command.Identification, command.EIdentificationType);
			var email = new Email(command.Email);
			var address = new Address(command.Street, command.Number, command.State, command.City, command.Country, command.ZipCode);
			var payerIdentification = new Identification(command.PayerIdentification, command.EPayerIdentificationType);

			//Generate Entities
			var student = new Student(name, identification, email);
			var subscription = new Subscription(null, null);
			var payment = new BoletoPayment(command.BoletoNumber, command.BarCode, payerIdentification, email, address,
											DateTime.Now, DateTime.Now.AddDays(30), command.Total, command.TotalPaid);

			//Relations
			subscription.AddPayment(payment);
			student.AddSubscription(subscription);

			//Grouping validations
			AddNotifications(name, identification, address, student, subscription, payment);

			//Verify notifications
			if(!IsValid)
				return new CommandResult(false, "It was not possible to realize your subscription");

			//Save informations
			_studentRepository.RegisterSubscription(student);

			//Send welcome e-mail
			_emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome to KKGarden interprise", "Your subscription is already valid");

			//Return informations
			return new CommandResult(true, "You were subscribed with successfully");
		}
	}
}

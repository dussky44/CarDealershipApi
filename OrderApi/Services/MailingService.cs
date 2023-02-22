using SendGrid.Helpers.Mail;
using SendGrid;
using OrderApi.Model;

namespace OrderApi.Services {
    public class MailingService {
        public async Task Execute(KafkaOrderRequest request) {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("djhusky@yahoo.ro", "Car Dealership");
            var subject = $"You just bouth a new {request.Car}";
            var to = new EmailAddress(request.Email, request.Name);
            var plainTextContent = $"Your new car cost {request.Price} and it is {request.Details}";
            var htmlContent = "<strong>Your new car cost {request.Price} and it is {request.Details}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}

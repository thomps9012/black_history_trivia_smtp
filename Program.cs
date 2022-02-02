using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

class Program
{
    static async Task Main()
    {
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("sthompson@norainc.org", "Samuel Thompson");
        var to = new EmailAddress("thomps9012@gmail.com", "Samuel Thompson");
        var subject = "Awesome String";
        var plainTextContent = "easy to do";
        var htmlContent = "<strong> really ... easy </strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
    }
}
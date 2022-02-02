using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SendGrid;
using SendGrid.Helpers.Mail;

public class Program {
    public static async void Main()
    {
        var message = new SendGridMessage();

        message.Personalizations = new List<Personalization>()
        {
            new Personalization()
            {
                Tos = new List<EmailAddress>()
                {
                    new EmailAddress()
                    {
                        Email = "thomps9012@gmail.com",
                        Name = "Test"
                    },
                    new EmailAddress()
                    {
                        Email = "sthompson@instructors.2u.com",
                        Name = "Test 2"
                    }
                },
                Ccs = new List<EmailAddress>()
                {
                    new EmailAddress()
                    {
                        Email = "sthompson@norainc.org",
                        Name = "Samuel Thompson"
                    },
                    new EmailAddress()
                    {
                        Email = "lrose-rodriguez@norainc.org",
                        Name = "Lisa Rose-Rodriguez"
                    }
                }
            }
        };

        message.From = new EmailAddress()
        {
            Email = "lrose-rodriguez@norainc.org",
            Name = "Lisa Rose-Rodriguez"
        };

        message.ReplyTo = new EmailAddress()
        {
            Email = "lrose-rodriguez@norainc.org",
            Name = "Lisa Rose-Rodriguez"
        };
        message.Subject = "Black History Fact of the Day!";
        message.Contents = new List<Content>()
        {
            new Content()
            {
                Type = "text/html",
                Value = "<p>Hello from the test email</p>"
            }
        };

        message.SendAt = 1617260400;

        message.BatchId = "Batch 1";

        message.Asm = new ASM()
        {
            GroupId = 1,
            GroupsToDisplay = new List<int>()
            {
                1
            }
        };

        message.TrackingSettings = new TrackingSettings()
        {
            ClickTracking = new ClickTracking()
            {
                Enable = true,
                EnableText = false
            },
            OpenTracking = new OpenTracking()
            {
                Enable = true
            }
        };

        string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        if (apiKey != null)
        {
            var client = new SendGridClient(apiKey);
            var response = await client.SendEmailAsync(message).ConfigureAwait(false);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync().Result);
            Console.WriteLine(response.Headers.ToString());
        }
    }
}
using ContactsBot.Domain;
using ContactsBot.Infrastructure;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactsBot
{
    public class ContactsBotFunction
    {
        private readonly IConfiguration _configuration;
        private readonly IMailSender _mailSender;

        public ContactsBotFunction(IConfiguration configuration, IMailSender mailSender)
        {
            _configuration = configuration;
            _mailSender = mailSender;
        }

        [FunctionName("ContactsBotFunction")]
        //public async Task Run([TimerTrigger("0 0 10 * * *")] TimerInfo myTimer, ILogger log)
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            //Build the policy
            var retryPolicy = Policy
                     .Handle<Exception>()
                     .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            try
            {
                //Execute the error prone code with the policy
                var attempt = 0;
                await retryPolicy.ExecuteAsync(async () =>
                {
                    log.LogInformation($"Attempt {++attempt}");
                    var contacts = await GetTodayBirthdaysAsync();
                    await SendBirthdayEmailNotification(contacts);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task SendBirthdayEmailNotification(ICollection<Contact> contacts)
        {
            if (contacts.Count == 0)
                return;

            var textBody = "<p>Los <strong>cumplea�eros</strong> de hoy son:</p>";
            textBody += "<ul>";
            foreach (var contact in contacts)
            {
                textBody += "<li>" + contact.Name + " " + contact.LastName + "</li>";
            }
            textBody += "</ul>";

            await _mailSender.Send(textBody);
        }

        private async Task<bool> SendMessageToContactAsync(Contact contact)
        {
            var result = false;
            try
            {
                var message = $"�Feliz cumple, {contact.Name}!. Te escribe Javier Guerrero para desearte un lindo d�a en compa�ia de familiares y amigos.";
                INotifier notifier = new Notifier();
                notifier.SendSms(contact.PhoneNumber, message);
            }
            catch (Exception ex)
            {
                //Logging
                throw;
            }

            return result;
        }

        private async Task<ICollection<Contact>> GetTodayBirthdaysAsync()
        {
            ICollection<Contact> todayBirthdays = new List<Contact>();

            try
            {
                HttpClient httpClient = new HttpClient();
                var request = await httpClient.GetAsync(_configuration["ContactsApi"]);
                request.EnsureSuccessStatusCode();

                var contacts = JsonSerializer.Deserialize<List<Contact>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                DateTime today = DateTime.Today;
                foreach (var contact in contacts)
                {
                    if (contact.Birthday.Day == today.Day && contact.Birthday.Month == today.Month)
                    {
                        todayBirthdays.Add(contact);
                    }
                }
            }
            catch (Exception ex)
            {
                // logging
                throw;
            }

            return todayBirthdays;
        }
    }
}
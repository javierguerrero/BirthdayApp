using ContactsBot.Infrastructure;
using ContactsBot.Domain;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MimeKit;

namespace ContactsBot
{
    public class ContactsBotFunction
    {
        private readonly IConfiguration _configuration;

        public ContactsBotFunction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("ContactsBotFunction")]
        public async Task Run([TimerTrigger("0 0 10 * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var contacts = await GetTodayBirthdaysAsync();
            await SendBirthdayEmailNotification(contacts);
        }

        private async Task SendBirthdayEmailNotification(ICollection<Contact> contacts)
        {
            //TODO: Implementar Inyección de dependencias en la Azure Function
            var smtpMailSender = new SmtpMailSender(_configuration);

            if (contacts.Count == 0)
                return;

            var textBody = "<p>Los <strong>cumpleañeros</strong> de hoy son:</p>";
            textBody += "<ul>";
            foreach (var contact in contacts)
            {
                textBody += "<li>" + contact.Name + " " + contact.LastName + "</li>";
            }
            textBody += "</ul>";

            await smtpMailSender.Send(textBody);
        }

        private async Task<bool> SendMessageToContactAsync(Contact contact)
        {
            var result = false;
            try
            {
                var message = $"¡Feliz cumple, {contact.Name}!. Te escribe Javier Guerrero para desearte un lindo día en compañia de familiares y amigos.";
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
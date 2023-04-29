using ContactsBot.Domain;
using Infrastructure.Notification;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactsBot
{
    public class ContactsBotFunction
    {
        [FunctionName("ContactsBotFunction")]
        public async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var contacts = await GetTodayBirthdaysAsync();
            foreach (var contact in contacts)
            {
                var result = await SendMessageToContactAsync(contact);
            }

            //https://damienaicheh.github.io/azure/azure-functions/dotnet/2022/05/10/use-settings-json-azure-function-en.html
        }

        public async Task<bool> SendMessageToContactAsync(Contact contact)
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

        public async Task<ICollection<Contact>> GetTodayBirthdaysAsync()
        {
            ICollection<Contact> todayBirthdays = new List<Contact>();

            try
            {
                HttpClient httpClient = new HttpClient();
                var request = await httpClient.GetAsync("https://app-contactsapi-prod.azurewebsites.net/contacts");
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
                    //if (contact.Birthday.Day == today.Day && contact.Birthday.Month == today.Month)
                    //{
                        todayBirthdays.Add(contact);
                    //}
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
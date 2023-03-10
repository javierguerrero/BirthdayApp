using Application.Contacts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BirthdayBot
{
    public class BirthdayBotFunctionApp
    {
        private readonly ILogger _logger;
        private readonly IContactService _contactService;

        public BirthdayBotFunctionApp(ILoggerFactory loggerFactory, IContactService contactService)
        {
            _logger = loggerFactory.CreateLogger<BirthdayBotFunctionApp>();
            _contactService = contactService;
        }

        [Function("BirthdayBotFunctionApp")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");


            var contacts = _contactService.GetTodayBirthdaysAsync().Result;
            foreach (var contact in contacts)
            {
                var result = await _contactService.SendMessageToContactAsync(contact);
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString($"OK {DateTime.Now.ToString()}");

            return response;
        }
    }
}
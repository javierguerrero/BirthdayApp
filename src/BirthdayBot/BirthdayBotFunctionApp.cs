using System.Net;
using Application.Contacts;
using Infrastructure.DataAccess;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

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

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var foo = await _contactService.GetAllAsync();
            var bar = foo.FirstOrDefault();


            response.WriteString(bar?.Name + " " + DateTime.Now.ToString());

            return response;
        }

        private void SendSMSMessage()
        {
            try
            {
                // Find your Account SID and Auth Token at twilio.com/console
                // and set the environment variables. See http://twil.io/secure
                string accountSid = "ACfdb02975b5150521dca1b9d389f57f33";
                string authToken = "ad4a0944d55df18e2d148551faa4ddcf";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: "Hi there",
                    from: new Twilio.Types.PhoneNumber("+15677042007"),
                    to: new Twilio.Types.PhoneNumber("+51976268172")
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

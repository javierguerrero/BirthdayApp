using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BirthdayBot
{
    public static class BirthdayBotFunctionApp
    {
        [FunctionName("BirthdayBotFunctionApp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            SendSMSMessage();


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            return (ActionResult)new OkObjectResult(DateTime.Now.ToString());
        }


        private static void SendSMSMessage()
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

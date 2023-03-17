using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Infrastructure.Notification
{
    public class Notifier : INotifier
    {
        public void SendSms(string toPhoneNumber, string message)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "";
            string authToken = "";

            TwilioClient.Init(accountSid, authToken);

            var messageResource = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("+15677042007"),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );
        }
    }
}
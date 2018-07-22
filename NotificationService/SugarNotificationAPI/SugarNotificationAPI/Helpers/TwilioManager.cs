using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace SugarNotificationAPI.Helpers
{
    public class TwilioManager
    {
        public MessageResource SendSmsMessage(string userNumber, string messageBody)
        {
            string accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            string authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            TwilioClient.Init(accountSid, authToken);

            var toUserNumber = new Twilio.Types.PhoneNumber(userNumber);
            var fromAppNumber = ConfigurationManager.AppSettings["TwilioPhoneNumber"];

            var messageResource = MessageResource.Create(
                to: toUserNumber,
                from: fromAppNumber,
                body: messageBody
            );

            return messageResource;
        }

        public MessagingResponse SendTwimlSmsMessage(string Body)
        {
            var twiml = new MessagingResponse();
            var messageResponse = twiml.Message($"{Body}");
            return messageResponse;
        }

        public MessagingResponse SendTwimlSmsMessage(string userName, string Body)
        {
            var twiml = new MessagingResponse();
            var messageResponse = twiml.Message($"Hey {userName}! {Body}");
            return messageResponse;
        }
    }
}
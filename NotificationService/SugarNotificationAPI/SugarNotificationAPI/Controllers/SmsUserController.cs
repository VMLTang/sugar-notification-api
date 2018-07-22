using SugarNotificationAPI.Helpers;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace SugarNotificationAPI.Controllers
{
    public class SmsUserController : TwilioController
    {
        // POST: SmsUser/RecieveMessage
        [HttpPost]
        public ActionResult RecieveMessage(string From, string Body)
        {
            var userManager = new UserManager();
            var twilioManager = new TwilioManager();

            //Future Call TODO:
            //var user = userManager.GetUserByPhoneNumberAsync(From);
            var userName = "Tang";

            switch (Body.ToUpper())
            {
                case "VERIFY":
                    {
                        //TODO:
                        //await userManager.VerifyPhoneNumber(From);
                        var messageResponse = twilioManager.SendTwimlSmsMessage(userName, "You are verified.");
                        return TwiML(messageResponse);
                    }
                case "CONFIRM":
                    {
                        //TODO:
                        //await var user = userManager.GetUserByPhoneNumberAsync(From);
                        //await var user = userManager.GetProducerForAcceptedRequestByConsumerPhoneNumber(From);
                        var producerName = "Jennifer";
                        var messageResponse = twilioManager.SendTwimlSmsMessage("We let " + producerName + " know. Glad it worked out!");
                        return TwiML(messageResponse);
                    }
                case "CHANGE":
                    {
                        //TODO:
                        //await var user = userManager.GetUserByPhoneNumberAsync(From);
                        //await var activeRequest = userManager.GetActiveAcceptedRequestByConsumerPhoneNumber(From);
                        var requestUrl = "shugarapp.com/requestId";
                        var producerName = "Jennifer";
                        var messageResponse = twilioManager.SendTwimlSmsMessage(
                            "What arrangement would be better for you? Go to " + requestUrl + " to let " + producerName + " know.");
                        return TwiML(messageResponse);
                    }
                default:
                    {
                        var twiml = new MessagingResponse();
                        var message = twiml.Message($"Hello {userName}! You said {Body}.");
                        return TwiML(message);
                    }
            }
        }
    }
}
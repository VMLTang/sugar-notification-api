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
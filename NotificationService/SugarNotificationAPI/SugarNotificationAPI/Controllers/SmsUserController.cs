using SugarNotificationAPI.Helpers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace SugarNotificationAPI.Controllers
{
    public class SmsUserController : TwilioController
    {
        // POST: SmsUser/RecieveMessage
        [HttpPost]
        public async Task<ActionResult> RecieveMessage(string From, string Body)
        {
            var userManager = new UserManager();
            var twilioManager = new TwilioManager();

            var user = await userManager.GetUserByPhoneNumberAsync(From);

            switch (Body.ToUpper())
            {
                case "VERIFY":
                    {
                        await userManager.VerifyPhoneNumber(From);
                        var messageResponse = twilioManager.SendTwimlSmsMessage(user.UserName, "You are verified.");
                        return TwiML(messageResponse);
                    }
                case "CONFIRM":
                    {
                        var userProducerTask = await userManager.GetProducerForAcceptedRequestByConsumerPhoneNumber(From);
                        var producerUser = userProducerTask;
                        await userManager.ConfirmMeeting(user.PhoneNumber, producerUser.PhoneNumber);

                        var producerName = producerUser.UserName ?? "Jennifer";
                        var messageResponse = twilioManager.SendTwimlSmsMessage("We let " + producerName + " know. Glad it worked out!");
                        return TwiML(messageResponse);
                    }
                case "CHANGE":
                    {
                        //TODO:
                        //await var activeRequest = userManager.GetActiveAcceptedRequestByConsumerPhoneNumber(user.PhoneNumber);
                        var requestUrl = "shugarapp.com/requestId";
                        var producerName = "Jennifer";
                        var messageResponse = twilioManager.SendTwimlSmsMessage(
                            "What arrangement would be better for you? Go to " + requestUrl + " to let " + producerName + " know.");
                        return TwiML(messageResponse);
                    }
                default:
                    {
                        var twiml = new MessagingResponse();
                        var message = twiml.Message($"Hello {user.UserName}! You said {Body}.");
                        return TwiML(message);
                    }
            }
        }
    }
}
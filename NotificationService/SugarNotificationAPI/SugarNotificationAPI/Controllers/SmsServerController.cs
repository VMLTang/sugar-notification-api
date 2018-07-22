using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using Twilio.Rest.Api.V2010.Account;
using SugarNotificationAPI.Helpers;
using System.Threading.Tasks;
using SugarNotificationAPI.Models;

namespace SugarNotificationAPI.Controllers
{
    public class SmsServerController : Controller
    {
        public ActionResult SendTestSms()
        {
            var twilioManager = new TwilioManager();
            string userNumber = "+17146750966";
            string messageBody = "This is a test message";

            var messageResource = twilioManager.SendSmsMessage(userNumber, messageBody);

            return Content(messageResource.Sid);
        }

        // POST: SmsServer/ConsumerRequestAccepted
        [HttpPost]
        public ActionResult ConsumerRequestAccepted(string ConsumerPhoneNumber, string ProducerName, string Time, string Place)
        {
            var twilioManager = new TwilioManager();
            var messageResource = twilioManager.SendSmsMessage(ConsumerPhoneNumber,
                "Great news! " + ProducerName + 
                " accepted your request. To pick up, meet at " + Time + " at " + Place + 
                ". If this works for you, reply CONFIRM. If not, reply CHANGE.") ;

            return Content(messageResource.Sid);
        }

        // POST: SmsServer/ProducerMeetupChangeRequestByConsumer
        [HttpPost]
        public ActionResult ProducerMeetupChangeRequestByConsumer(string ProducerPhoneNumber, string ConsumerName, string RequestUrl)
        {
            var twilioManager = new TwilioManager();
            var messageResource = twilioManager.SendSmsMessage(ProducerPhoneNumber,
                ConsumerName + " would like to revise the meet up. Click here to view and confirm: " + RequestUrl);

            return Content(messageResource.Sid);
        }

        // POST: SmsServer/ProducerMeetupConfirmed
        [HttpPost]
        public ActionResult ProducerMeetupConfirmed(string ProducerPhoneNumber, string ConsumerName, string Time, string Place)
        {
            var twilioManager = new TwilioManager();
            var messageResource = twilioManager.SendSmsMessage(ProducerPhoneNumber,
                ConsumerName + " has confirmed and will see you at " + Time + " at " + Place + ".");

            return Content(messageResource.Sid);
        }

        // POST: SmsServer/ProducerRequestAccepted
        [HttpPost]
        public ActionResult ProducerRequestAccepted(string ProducerPhoneNumber, string ConsumerName)
        {
            var twilioManager = new TwilioManager();
            var messageResource = twilioManager.SendSmsMessage(ProducerPhoneNumber, "Thanks for offering to help! Just waiting for a confirmation from " + ConsumerName + ".");

            return Content(messageResource.Sid);
        }

        // POST: SmsServer/BroadcastRequest
        [HttpPost]
        public ActionResult BroadcastRequest(BroadcastRequestModel request)
        {
            var twilioManager = new TwilioManager();

            foreach (var smsUser in request.PhoneNumbers)
            {
                twilioManager.SendSmsMessage(smsUser.PhoneNumber, "Hey " + smsUser.Name + "! " + request.Message);
            }

            return Content("Request " + request.RequestUrl + " has been sent to " + request.PhoneNumbers.Count() + " recipents.");
        }

        // POST: SmsServer/Verify
        [HttpPost]
        public ActionResult Verify(string PhoneNumber)
        {
            var twilioManager = new TwilioManager();
            var messageResource = twilioManager.SendSmsMessage(PhoneNumber, "Welcome to Shugar! Reply 'VERIFY' to confirm this number.");

            return Content("Verification message sent to " + PhoneNumber + ". SID: " + messageResource.Sid);
        }

        // POST: SmsServer/Message
        [HttpPost]
        public ActionResult Message(string ToPhoneNumber, string UserDisplayName, string MessageBody)
        {
            var twilioManager = new TwilioManager();
            //Future Call TODO:
            //var userManager = new UserManager();
            //var user = userManager.GetUserByPhoneNumberAsync(From);

            var message = "Hey " + UserDisplayName + "! " + MessageBody;

            var messageResource = twilioManager.SendSmsMessage(ToPhoneNumber, message);

            return Content(messageResource.Sid);
        }
    }
}
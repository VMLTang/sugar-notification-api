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

namespace SugarNotificationAPI.Controllers
{
    public class SmsServerController : Controller
    {
        //// GET: SendSms
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: smsserver/sendsms
        public ActionResult SendSms()
        {
            string userNumber = "+17146750966";
            string messageBody = "This is a test message";

            var messageResource = SendSmsMessage(userNumber, messageBody);

            return Content(messageResource.Sid);
        }

        // POST: SmsServer/Verify
        [HttpPost]
        public ActionResult Verify(string PhoneNumber)
        {
            var messageResource = SendSmsMessage(PhoneNumber, "Welcome to Shugar! Reply 'VERIFY' to confirm this number.");

            return Content("Verification message sent to " + PhoneNumber + ". SID: " + messageResource.Sid);
        }

        // POST: SmsServer/Message
        [HttpPost]
        public ActionResult Message(string ToPhoneNumber, string UserDisplayName, string MessageBody)
        {
            //Future Call TODO:
            //var userManager = new UserManager();
            //var user = userManager.GetUserByPhoneNumberAsync(From);

            var message = "Hey " + UserDisplayName + "! " + MessageBody;

            var messageResource = SendSmsMessage(ToPhoneNumber, message);

            return Content(messageResource.Sid);
        }

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
    }
}
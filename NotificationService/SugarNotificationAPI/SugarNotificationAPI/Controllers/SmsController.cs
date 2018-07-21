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

namespace SugarNotificationAPI.Controllers
{
    public class SmsController : Controller
    {
        // GET: Sms
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendSms(string toNumber, string message)
        {
            string accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            string authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];

            TwilioClient.Init(accountSid, authToken);

            string userNumber = toNumber ?? "+17146750966";
            string messageBody = message ?? "This is a test message";

            var toUserNumber = new Twilio.Types.PhoneNumber(userNumber);
            var fromAppNumber = ConfigurationManager.AppSettings["TwilioPhoneNumber"];

            var messageResource = MessageResource.Create(
                to: toUserNumber,
                from: fromAppNumber,
                body: messageBody
            );

            return Content(messageResource.Sid);
        }
    }
}
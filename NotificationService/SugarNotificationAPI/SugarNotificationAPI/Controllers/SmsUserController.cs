using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace SugarNotificationAPI.Controllers
{
    public class SmsUserController : TwilioController
    {
        // GET: SmsUser
        public ActionResult Index()
        {
            return View();
        }

        // POST: Sms/Message
        [HttpPost]
        public ActionResult Message(string From, string Body)
        {
            var twiml = new MessagingResponse();
            var message = twiml.Message($"Hello {From}. You said {Body}");
            return TwiML(message);
        }
    }
}
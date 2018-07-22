using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class BroadcastRequestModel
    {
        public string RequestUrl { get; set; }
        public string Message { get; set; }
        public List<SmsUser> PhoneNumbers { get; set; }
    }

    public class SmsUser
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
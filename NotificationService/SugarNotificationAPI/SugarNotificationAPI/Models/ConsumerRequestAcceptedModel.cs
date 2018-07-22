using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class ConsumerRequestAcceptedModel
    {
        public string ConsumerPhoneNumber { get; set; }
        public string ProducerName { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }
    }
}
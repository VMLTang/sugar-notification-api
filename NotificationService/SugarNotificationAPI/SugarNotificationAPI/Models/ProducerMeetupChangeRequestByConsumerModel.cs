using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class ProducerMeetupChangeRequestByConsumerModel
    {
        public string ProducerPhoneNumber { get; set; }
        public string ConsumerName { get; set; }
        public string RequestUrl { get; set; }
    }
}
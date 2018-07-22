using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class ProducerMeetupConfirmedModel
    {
        public string ProducerPhoneNumber { get; set; }
        public string ConsumerName { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class MeetingConfirmModel
    {
        public string Type { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string ProducerPhoneNumber { get; set; }
        public string ProducerName { get; set; }
        public string ConsumerPhoneNumber { get; set; }
        public string ConsumerName { get; set; }
    }
}
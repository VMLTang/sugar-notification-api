using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class ProducerOfferSelectedModel
    {
        public string ProducerPhoneNumber { get; set; }
        public string ProducerName { get; set; }
        public string ConsumerName { get; set; }
        public string OfferUrl { get; set; }
    }
}
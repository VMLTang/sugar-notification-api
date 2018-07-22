using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class GenericMessageModel
    {
        public string ToPhoneNumber { get; set; }
        public string UserDisplayName { get; set; }
        public string MessageBody { get; set; }
    }
}
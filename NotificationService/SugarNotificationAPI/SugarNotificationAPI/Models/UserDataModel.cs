using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    [JsonObject]
    public class UserDataModel
    {
        [JsonProperty("name")]
        public string UserName { get; set; }
        [JsonProperty("cellNumber")]
        public string PhoneNumber { get; set; }

        public static implicit operator UserDataModel(string v)
        {
            throw new NotImplementedException();
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    [JsonObject]
    public class CreateOfferModel
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("pickupLocation")]
        public Location pickupLocation { get; set; }
        [JsonProperty("expireAt")]
        public string expiresAt { get; set; }
        [JsonProperty("content")]
        public OfferContent content { get; set; }
        [JsonProperty("createdBy")]
        public int createdBy { get; set; }
    }

    [JsonObject]
    public class Location
    {
        [JsonProperty("lat")]
        public double lat { get; set; }
        [JsonProperty("long")]
        public double @long { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
    }

    [JsonObject]
    public class OfferContent
    {
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("item")]
        public string item { get; set; }
        [JsonProperty("quantity")]
        public int quantity { get; set; }
    }
}
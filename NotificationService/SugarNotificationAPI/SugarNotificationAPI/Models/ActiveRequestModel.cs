using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SugarNotificationAPI.Models
{
    public class ActiveRequestModel
    {
        public string PostingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostingType { get; set; }
        public string PostAuthorId { get; set; }
        public string PostAuthorName { get; set; }
    }
}
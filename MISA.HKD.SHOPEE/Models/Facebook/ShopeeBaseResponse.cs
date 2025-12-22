using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class FacebookBaseResponse
    {
        [JsonProperty("error")]
        public FacebookError error { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; } = true;
    }
}
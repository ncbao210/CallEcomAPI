using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class FacebookConfig
    {
        public string FacebookGraphUrl { get; set; } = "https://graph.facebook.com/v20.0/";
        public string FacebookGrapVideoUrl { get; set; } = "https://graph-video.facebook.com/v20.0/";

        public int RetryNumber { get; set; } = 1;

        public string FacebookAppId { get; set; } = "834674018755282";
        public string FacebookAppSecret { get; set; } = "7b905d83d00acb37e51f8585a4e7027a";

        

        /// <summary>
        /// Giới hạn số reuqest sang facebook trong 1 lần call
        /// Mặc định của FB là 50
        /// </summary>
        public int BatchLimitRequest { get; set; } = 50;

    }
}
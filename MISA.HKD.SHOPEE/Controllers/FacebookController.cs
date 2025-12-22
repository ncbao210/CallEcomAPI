using MISA.HKD.SHOPEE.ADO;
using MISA.HKD.SHOPEE.Models;
using MISA.HKD.SHOPEE.Utility;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.UI;

namespace MISA.HKD.SHOPEE.Controllers
{
    public class FacebookController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/facebook/5
        public string Get(int id)
        {

            FacebookGraphUtilities facebookGraphUtilities = new FacebookGraphUtilities();
            //var pageToken = "EAAL3IbBkItIBO2OcAHnQYKDpgkvv1OpFHesUOPT3flnHN5J8fLVGTAT8QUx4FUZA0ceIA19KCdlxdwGsj4mQmF57O07DYsZCZBLAw1GrmfIK5xQnNbpHPAjh1S6DgasvUmynjQC2PBvoLaQAT57LxLs4tHw5t69lZC7qRcHz7NZCjDyOeOvZB8cUUUmAhmBqxJpiUmoqiw6AXC68Smkzgj42EYYQZDZD";
            //var token = "aAAL3IbBkItIBO9j6gn1lmttDLOi9qMjtfVEuV8Ss2eSEZCvpCaE50Q2zo6eBCUpp48W57WtaEi9TaRnEt7XZC489SxxvHTb7HUgY6X5Pmt58IZB1N3hvfoKuUYYyZBj6sakzVGyKFj8EOCwDn5KeMDCZCFcp6ZA7EcNP2PyBtTXwltJbFS05oYRaDpLOLKbASqZApOGxke5P0ug4jJcxZAkcp5mf";



            string pageID = "378828585321124";
            //string captions = "hello, vuz post by code";
            //string postProducts = FacebookEndpoint.PostProducts;
            //postProducts = string.Format(postProducts, pageToken, pageID, HttpUtility.UrlEncode(captions));
            //var param = new FaceBookBaseParam<object>()
            //{
            //    AccessToken = token
            //};
            //var response = facebookGraphUtilities.CallFacebookGraphAPI<object, FacebookBaseResponse>(param, Method.POST, postProducts);

            var token = "EAAL3IbBkItIBOx35w4hRPB5gJbqQ1PqokZAu39DO4tVRIf2tWq8E4keVNEZCuECPt8DZCUCYDfqGPErzMDelNKfhaICCxiI7NFnmPFWukfZCpNAMZCGdzIZApnp6khDodiy7bKtEYZB2UhHLwj8pZAZAeJgt2m6cv1TKIXjRjPoviSbTj8yaLdcSWxNSzH7SVRcT8hbQjHI2rLWD7xdqGZBpiV7znT";
            var utoken = "EAAL3IbBkItIBO069T1IfKG9QZB7Fck2Aan7HXMpFHct4lwD6XTLCEJr6ArRwz6CDnqyFwQSqhejp067eg5PZAW1QpN6TqkRTW9FuByl2l9KF5MMKUxnR09SCEpJ005rE6nKu9VByGmXBYQ1EkYjASRIL6L2wsZAJcTUiuRV8mjWl9whuwbd2erVktWRZBBxwDW7q9HZAEgdw1k3Sddl8ZD";
            //var res = facebookGraphUtilities.UploadVideo("C:\\Users\\ntan\\Downloads\\1072815-hd_1920_1080_30fps.mp4", token, pageID, pageToken);
            //var resGPT = facebookGraphUtilities.UploadVideo("C:\\Users\\ntan\\Downloads\\natural_calm_lake_at_dusk_6891961\\lake_clouds_forest_nature_dark_595.mp4", token, pageID, pageToken);

            //var publishVideoParam = new PublishPostVideoParam()
            //{
            //    AccessToken = pageToken,
            //    PageID = pageID,
            //    FileName = "ntvu1Upload",
            //    FilePath = "C:\\Users\\ntan\\Downloads\\natural_calm_lake_at_dusk_6891961\\lake_clouds_forest_nature_dark_595.mp4",
            //    Body = new PublishPostVideoBody()
            //    {
            //        title = "ntvu1 upload video title",
            //        description = "ntvu1 upload video description"
            //    }
            //};
            //var resss = facebookGraphUtilities.PublishPostVideo(publishVideoParam);
            //var res = UpdatePost(utoken, "378828585321124_122100234218495387");

            //var res = facebookGraphUtilities.UploadVideo("C:\\Users\\ntan\\Downloads\\natural_calm_lake_at_dusk_6891961\\lake_clouds_forest_nature_dark_595.mp4", token, pageID);
            //var res = fackebookGraphUtilities.UploadImage("C:\\Users\\ntan\\Downloads\\images.jpg", token, pageID);
            //var res2 = facebookGraphUtilities.UploadImage("C:\\Users\\ntan\\Downloads\\images.png", token, pageID);
            //var res3 = facebookGraphUtilities.UploadVideo("C:\\Users\\ntan\\Downloads\\1072815-hd_1920_1080_30fps.mp4", token, pageID, false, res.Result);
            //var res4 = facebookGraphUtilities.UploadVideo("C:\\Users\\ntan\\Downloads\\1072815-hd_1920_1080_30fps.mp4", token, pageID, true, res.Result);

            //var post = CreatePost(token, pageID, new List<string>() { res.Result, res2.Result, "378828585321124_122101056980495387" });
            //UpdatePost(token, "378828585321124_122101076480495387", res.Result);

            //var res = PostProduct(pageID, token);
            var res = UpdatePost(token, "122101193888495387", pageID, "");


            return JsonConvert.SerializeObject("hello");


        }
        public async Task<PartnerApiResponse> PostProduct(string pageID, string token)
        {
            FacebookGraphUtilities facebookGraphUtilities = new FacebookGraphUtilities();
            var route = string.Format(FacebookEndpoint.PostProduct, pageID);

            var param = new FBPostProductParam()
            {
                AccessToken = token,
                PageID = pageID,
                Body = new FBPostProductBody()
                {
                    url = "https://scontent.fhan2-4.fna.fbcdn.net/v/t39.30808-6/457105508_122101045256495387_200435565781314677_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=127cfc&_nc_ohc=pN4REmJln-4Q7kNvgG0RWnd&_nc_ht=scontent.fhan2-4.fna&edm=AKIiGfEEAAAA&oh=00_AYCEBVJD2mnMRB1EaTHovqe3XKy8t2BaUA8TfcJk9K8q3g&oe=66D36099",
                    caption = "ntvu1 caption schedule",
                    published = false,
                    scheduled_publish_time = (Int32)(TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(30))).Subtract(DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc)).TotalSeconds
                    }


            };

            var res = await facebookGraphUtilities.CallFacebookGraphAPI<FBPostProductBody, FBPostProductResponse>(param, Method.POST, route);

            return res;

        }

        public async Task<PartnerApiResponse> UpdatePost(string token, string id, string pageID, string attach)
        {
            var param = new UpdatePostParam()
            {
                AccessToken = token,
                ID = id,
                Body = new UpdatePostBody()
                {
                    //attached_media = new List<AttachMedia> { new AttachMedia() { media_fbid = attach } },
                    description = "update description",
                    message = "update message pin",
                    scheduled_publish_time = (Int32)(TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(15))).Subtract(DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc)).TotalSeconds
                    //is_published = true

                }
            };
            FacebookGraphUtilities facebookGraphUtilities = new FacebookGraphUtilities();
            string route = $"/{pageID}_{id}";
            string facebookUrl = string.Format($"https://graph.facebook.com/v20.0");
            var res = await facebookGraphUtilities.CallFacebookGraphAPI<UpdatePostBody, FacebookBaseResponse>(param, Method.POST, route, facebookGraphUrl: facebookUrl);
            return res;
        }
        public async Task<string> CreatePost(string token, string pageId, List<string> medias)
        {
            FacebookGraphUtilities facebookGraphUtilities = new FacebookGraphUtilities();
            var media = new List<AttachMedia>() { };
            medias.ForEach(id =>
            {
                media.Add(new AttachMedia() { media_fbid = id });
            });
            var param = new CreatePostParam()
            {
                AccessToken = token,
                PageID = pageId,
                Body = new CreatePostBody()
                {
                    message = "nvlong message",
                    description = "ddkhang description",

                    attached_media = media
                }
            };
            var route = string.Format(FacebookEndpoint.PostTextPublish, pageId);
            var res = await facebookGraphUtilities.CallFacebookGraphAPI<CreatePostBody, FacebookBaseResponse>(param, Method.POST, route);


            return "ntvu1";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

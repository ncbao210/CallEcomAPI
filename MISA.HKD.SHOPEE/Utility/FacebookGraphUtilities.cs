

using MISA.HKD.SHOPEE.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace MISA.HKD.SHOPEE.Utility
{
    public class FacebookGraphUtilities
    {
        protected FacebookConfig _facebookConfig;
        /// <summary>
        /// Ctor
        /// </summary>
        public FacebookGraphUtilities()
        {
            _facebookConfig = new FacebookConfig();
        }

        /// <summary>
        /// Gọi một loạt yêu cầu Facebook một cách bất đồng bộ.
        /// </summary>
        /// <param name="param">Các tham số cơ bản của Facebook.</param>
        /// <param name="requests">Danh sách các yêu cầu hàng loạt.</param>
        /// <param name="retryNumber">Số lần thử lại. Tùy chọn.</param>
        /// <returns>Một task đại diện cho hoạt động bất đồng bộ. Kết quả task chứa phản hồi từ API.</returns>
        /// ntvu1 22.8.2024
        public async Task<PartnerApiResponse> CallBatchFacebookRequest(FaceBookBaseParam<object> param, List<FacebookBatchRequest> requests, int retryNumber = -1)
        {
            //Mặc định 50
            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();
            List<FacebookBatchResponse> res = new List<FacebookBatchResponse>();
            try
            {
                int limit = _facebookConfig.BatchLimitRequest;
                string facebookGraphUrl = _facebookConfig.FacebookGraphUrl;
                int countRequests = requests.Count;
                double count = (double)countRequests / (double)limit;
                double countCall = Math.Ceiling(count);

                if (retryNumber == -1)
                {
                    retryNumber = _facebookConfig.RetryNumber;
                }

                for (int i = 0; i < countCall; i++)
                {
                    List<FacebookBatchRequest> listrequests = requests.GetRange(i * limit, (countRequests - (i * limit)) > limit ? limit : (countRequests - (i * limit)) < 0 ? countRequests : (countRequests - (i * limit)));
                    if (listrequests?.Count > 0)
                    {
                        RestClient client = new RestClient(facebookGraphUrl);
                        RestRequest request = new RestRequest(Method.POST);

                        FacebookBatchParam facebookBatchParam = new FacebookBatchParam
                        {
                            AccessToken = param.AccessToken,
                            Batch = JsonConvert.SerializeObject(listrequests)
                        };
                        request.AddParameter("batch", facebookBatchParam.Batch);
                        request.AddParameter("access_token", facebookBatchParam.AccessToken);


                        IRestResponse<List<FacebookBatchResponse>> response = client.Execute<List<FacebookBatchResponse>>(request);

                        if (response != null)
                        {
                            partnerApiResponse.Code = (int)response.StatusCode;
                            partnerApiResponse.Message = response.ErrorMessage;
                            //_loggerPartner.LogDebug($"CallBatchRequestFacebook response => {JsonConvert.SerializeObject(request.Parameters)} -/- {response.Content}");
                            if (!response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Content))
                            {

                                FacebookBaseResponse baseResponse = JsonConvert.DeserializeObject<FacebookBaseResponse>(response.Content);
                                // kiểm tra xem có lỗi 190 không?
                                if (baseResponse != null && baseResponse.error != null && baseResponse.error.Code == (int)FacebookErrorCode.InvalidOAuthAccessToken && retryNumber > 0)
                                {
                                    PartnerApiResponse refreshTokenRes = await GetLongLiveAccessToken(param.AccessToken);

                                    // nếu gọi refresh token mà không bị lỗi thì thực hiện gọi lô danh sách request lên Facebook với accessToken mới
                                    if (refreshTokenRes.Success && refreshTokenRes.Data != null)
                                    {
                                        var tokenData = (FacebookGetTokenResponse)refreshTokenRes.Data;
                                        if (tokenData != null)
                                        {
                                            param.AccessToken = tokenData.AccessToken;
                                            param.DataExtend = tokenData;
                                            return await CallBatchFacebookRequest(param, listrequests, retryNumber - 1);
                                        }

                                    }
                                    else
                                    {
                                        FacebookBatchResponse facebookBatchRequestResponse = new FacebookBatchResponse();
                                        facebookBatchRequestResponse.code = (int)FacebookErrorCode.InvalidOAuthAccessToken;
                                        facebookBatchRequestResponse.body = "Đã hết phiên làm việc, vui lòng đăng nhập lại";
                                        res.Add(facebookBatchRequestResponse);

                                        partnerApiResponse.ErrorPartner = (int)FacebookErrorCode.InvalidOAuthAccessToken;
                                        partnerApiResponse.Data = res;
                                        partnerApiResponse.Success = false;
                                        partnerApiResponse.Message = "Đã hết phiên làm việc, vui lòng đăng nhập lại";
                                        return partnerApiResponse;
                                    }
                                }
                                else if (baseResponse != null && baseResponse.error != null)
                                {
                                    //_loggerPartner.LogInformation($"MakeBatchRequest => {ErrorFaceBook.Error.Message} - {ErrorFaceBook.Error.Code}");
                                    partnerApiResponse.OnError(baseResponse.error.Message);
                                    partnerApiResponse.ErrorPartner = baseResponse.error.ErrorSubCode;

                                }

                            }

                            if (response.Data?.Count > 0)
                            {
                                res.AddRange(response.Data);
                            }
                        }
                        else
                        {
                            //_loggerPartner.LogInformation($"MakeBatchRequest => POST call request faceBook is Null");
                            partnerApiResponse.Success = false;
                            partnerApiResponse.Message = "post call request facebook is null";
                        }

                    }
                }

                if (param.DataExtend != null)
                {
                    partnerApiResponse.DataExtend = param.DataExtend;
                }

                partnerApiResponse.Data = res;
            }
            catch (Exception ex)
            {
                //_loggerPartner.LogError($"CallBatchRequest exception => {ex.Message}");
                partnerApiResponse.OnException(ex);

            }

            return partnerApiResponse;
        }

        /// <summary>
        /// Làm mới token Facebook một cách bất đồng bộ.
        /// </summary>
        /// <param name="oldAccessToken">Token truy cập cũ.</param>
        /// <returns>Một task đại diện cho hoạt động bất đồng bộ. Kết quả task chứa phản hồi từ API.</returns>
        /// /// ntvu1 22.8.2024
        public async Task<PartnerApiResponse> GetLongLiveAccessToken(string oldAccessToken)
        {
            var response = new PartnerApiResponse();
            try
            {
                string facebookGraphUrl = _facebookConfig.FacebookGraphUrl;

                var client = new RestClient(facebookGraphUrl);

                string facebookAppID = _facebookConfig.FacebookAppId;
                string facebookAppSecret = _facebookConfig.FacebookAppSecret;

                string route = string.Format(FacebookEndpoint.GetLongLivedAccessToken, facebookAppID, facebookAppSecret, oldAccessToken);

                var request = new RestRequest(route, Method.GET);

                var tokenResponse = client.Execute<FacebookGetTokenResponse>(request);

                if (tokenResponse != null && tokenResponse.ErrorException == null && tokenResponse.Data != null && !string.IsNullOrWhiteSpace(tokenResponse.Data.AccessToken) && tokenResponse.Data.error == null)
                {
                    response.Success = true;
                    response.Data = tokenResponse.Data;
                }
                else
                {
                    response.Error = "Response is null";
                    response.Success = false;
                    response.Code = (int)FacebookErrorCode.InvalidOAuthAccessToken;
                }
            }
            catch (Exception ex)
            {
                response.OnException(ex);
            }
            return response;
        }

        public async Task<PartnerApiResponse> CallFacebookGraphAPI<TBody, TData>(FaceBookBaseParam<TBody> param, Method method, string route, RestRequest request = null, int retryNumber = -1, string facebookGraphUrl = "") where TData : FacebookBaseResponse
        {
            var response = new PartnerApiResponse();

            try
            {
                if (retryNumber == -1)
                {
                    retryNumber = _facebookConfig.RetryNumber;
                }

                if (string.IsNullOrEmpty(facebookGraphUrl))
                {
                    facebookGraphUrl = _facebookConfig.FacebookGraphUrl;
                }

                var client = new RestClient(facebookGraphUrl);
                if (request == null)
                {
                    request = new RestRequest(route, method);
                }
                // nếu có token thì gắn token vào cả query và body
                if (!string.IsNullOrWhiteSpace(param.AccessToken))
                {
                    request.AddOrUpdateParameter("access_token", param.AccessToken);
                    request.AddQueryParameter("access_token", param.AccessToken);
                }

                if (method != Method.GET && param != null)
                {
                    if (param.Body != null)
                    {
                        request.AddJsonBody(param.Body);
                    }
                    if (param.Parameters?.Count > 0)
                    {
                        foreach (var item in param.Parameters)
                        {
                            request.AddParameter(item.Key, item.Value);
                        }
                    }
                }

                var clientResponse = client.Execute<TData>(request);

                if (clientResponse != null)
                {
                    response.Code = (int)clientResponse.StatusCode;
                    response.Message = clientResponse.ErrorMessage;

                    // Log
                    bool logged = false;

                    if (logged || string.IsNullOrEmpty(clientResponse.Content))
                    {
                        // Force ghi lại log dù ở mode nào đi nữa
                        string responseLog = string.IsNullOrEmpty(clientResponse.Content) ? clientResponse.ErrorMessage : clientResponse.Content;

                    }
                    else
                    {
                        /*_loggerPartner.LogInformation(clientResponse.Content)*/
                        ;
                    }

                    FacebookBaseResponse facebookBaseResponse = null;

                    if (clientResponse.ErrorException != null || clientResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    {

                        //Force log trường hợp call api facebook có lỗi
                        //_loggerPartner.LogError($"CallGraphFacebookAPI => lỗi errorException");

                        if (!string.IsNullOrWhiteSpace(clientResponse.Content))
                        {
                            facebookBaseResponse = JsonConvert.DeserializeObject<FacebookBaseResponse>(clientResponse.Content);
                        }
                    }

                    if (facebookBaseResponse == null && clientResponse.Data != null)
                    {
                        try
                        {
                            var fbResponse = (FacebookBaseResponse)clientResponse.Data;
                            if (fbResponse?.error != null)
                            {
                                facebookBaseResponse = fbResponse;
                            }
                        }
                        catch (Exception ex)
                        {
                            //_loggerPartner.LogWarning($"CallGraphFacebookAPI => Data is not FacebookBaseResponse, exception = {ex}");
                        }
                    }


                    // nếu là lỗi token hết hạn thì refresh token và gọi lại API
                    if (facebookBaseResponse?.error != null)
                    {
                        if (facebookBaseResponse.error.Code == (int)FacebookErrorCode.InvalidOAuthAccessToken && retryNumber > 0)
                        {
                            PartnerApiResponse refreshTokenRes = await GetLongLiveAccessToken(param.AccessToken);

                            if (refreshTokenRes.Success && refreshTokenRes.Data != null)
                            {
                                var tokenData = (FacebookGetTokenResponse)refreshTokenRes.Data;
                                if (tokenData != null)
                                {
                                    param.AccessToken = tokenData.AccessToken;
                                    param.DataExtend = tokenData;

                                    return await CallFacebookGraphAPI<TBody, TData>(param: param, method: method, route: route, retryNumber: retryNumber - 1);
                                }

                            }
                            response.OnError((int)FacebookErrorCode.InvalidOAuthAccessToken);
                        }
                        else
                        {
                            response.OnError(facebookBaseResponse.error.Message, null, facebookBaseResponse.error.Code);
                            response.ErrorPartner = facebookBaseResponse.error.ErrorSubCode;
                        }
                    }
                    else if (clientResponse.ErrorException != null)
                    {
                        /*LogUtil.DebugInfoLogging($"CallGraphFacebookAPI ({method} {facebookGraphUrl}{endpoint}) => Non-190 error: ErrorException = {response.ErrorException}, Response Content = {response.Content}")*/

                        response.OnException(clientResponse.ErrorException);
                    }
                    else
                    {
                        response.OnSuccess(clientResponse.Data);
                    }

                }
                else
                {
                    response.OnError("ClientResponse is null");
                }

                if (param.DataExtend != null)
                {
                    response.DataExtend = param.DataExtend;
                }
            }
            catch (Exception ex)
            {
                response.OnException(ex);
            }

            return response;
        }

        /// <summary>
        /// Lấy thông tin người dùng từ facebook
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// ntvu1 22.08.2024
        public async Task<PartnerApiResponse> GetUserInfo(FaceBookBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();

            string getCurrentUserInfoAdmin = FacebookEndpoint.GetCurrentUserInfoAdmin;

            var endPoint = string.Format(getCurrentUserInfoAdmin, param.AccessToken);

            response = await CallFacebookGraphAPI<object, FacebookGetUserInfo>(param, RestSharp.Method.GET, endPoint);
            return response;
        }

        public async Task<PartnerApiResponse> ExampleBatchRequest(string accessToken, string pageId, string after = "")
        {
            DateTime fromDay = DateTime.ParseExact("13/08/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime toDay = DateTime.ParseExact("13/09/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            PartnerApiResponse response = new PartnerApiResponse();
            var batchRequests = new List<FacebookBatchRequest>();
            string getPagePostsForAutoMessage = FacebookEndpoint.GetSingleComment;
            var endpoint = string.Format(getPagePostsForAutoMessage, accessToken, pageId, "");
            batchRequests.Add(new FacebookBatchRequest()
            {
                RelativeUrl = endpoint,
                Method = "GET"
            });
            var param = new FaceBookBaseParam<object>()
            {
                AccessToken = accessToken
            };

            var batchResponses = await CallBatchFacebookRequest(param, batchRequests);
            return response;
        }

        public async Task<PartnerApiResponse> ReplyComment(string token, string commentID, string message)
        {
            string replyComment = FacebookEndpoint.ReplyCommentWithImage;
            var _endpoint = string.Format(replyComment, token, commentID, HttpUtility.UrlEncode("https://www.facebook.com/photo/?fbid=122096855324495387&set=a.122096855366495387"));

            //var parameters = new Dictionary<string, object>
            //{
            //    { "message", message }
            //};

            var param = new FaceBookBaseParam<object>
            {
                AccessToken = token
                //Parameters = parameters
            };
            var ress = await CallFacebookGraphAPI<object, FacebookBaseResponse>(param, Method.POST, _endpoint);

            //var newBody = new
            //{
            //    message
            //};

            //var request = new FacebookBatchRequest()
            //{
            //    Method = "POST",
            //    Body = "message=Commentss by vuzzz",
            //    RelativeUrl = _endpoint
            //};
            //var listRequest = new List<FacebookBatchRequest>()
            //{
            //    request,
            //    request,
            //    request

            //};

            //var commentss = await CallBatchFacebookRequest(param, listRequest);

            return ress;
        }


        //public async Task<PartnerApiResponse> PublishPostVideo(PublishPostVideoParam param)
        //{
        //    var response = new PartnerApiResponse();
        //    if (param != null)
        //    {

        //        var res = await UploadVideo(param);

        //        if (res.Success && res.Data != null)
        //        {
        //            var resData = (FacebookUploadVideoFinishRes)res.Data;
        //            param.Body.upload_session_id = resData.upload_session_id;

        //            var resPublishPost = await CallFacebookGraphAPI<PublishPostVideoBody, FacebookBaseResponse>(param, RestSharp.Method.POST, string.Empty, facebookGraphUrl: $"{_facebookConfig.FacebookGrapVideoUrl}/{param.PageID}/videos");
        //            return resPublishPost;
        //        }

        //    }
        //    else
        //    {
        //        response.OnError("PublishPostVideo Param is null");
        //    }

        //    return response;
        //}

        public async Task<PartnerApiResponse> UploadVideo(string path, string token, string pageID, bool isPublish = false, string attached="")
        {
            byte[] videoBytes = File.ReadAllBytes(path);
            var param = new FacebookUploadVideoParam<PublishPostVideoBody>()
            {
                AccessToken = token,
                FileName = "ntvu1",
                FileType = "video/mp4",
                PageID = pageID,
                FileBytes = videoBytes,
                Body = new PublishPostVideoBody()
                {
                    title = "ntvu1 title 27.8.2024",
                    description = "ntvu1 description 27.8.2024",
                    published = isPublish,
                    attached_media = new List<AttachMedia>()
                    {
                        new AttachMedia(){
                            media_fbid = attached,
                        }

                    }
                }
            };

            var res = await UploadPageVideo(param);
            if (res.Success && res.Data != null)
            {
                var resData = (FacebookUploadVideoFinishRes)res.Data;
                param.Body.upload_session_id = resData.upload_session_id;

                var resPublishPost = await CallFacebookGraphAPI<PublishPostVideoBody, FBUploadAttachmentRes>(param, RestSharp.Method.POST, string.Empty, facebookGraphUrl: $"{_facebookConfig.FacebookGrapVideoUrl}/{param.PageID}/videos");
                return resPublishPost;
            }
            return new PartnerApiResponse();
        }

        public async Task<PartnerApiResponse> UploadPageVideo<T>(FacebookUploadVideoParam<T> param, bool isRetry = true) where T : FacebookUploadVideoBody
        {
            var response = new PartnerApiResponse();
            try
            {
                var fileSize = param.FileBytes.Length;

                var client = new RestClient($"{_facebookConfig.FacebookGrapVideoUrl}/{param.PageID}/videos");
                var initRequest = new RestRequest(Method.POST);

                initRequest.AddParameter("access_token", param.AccessToken);
                initRequest.AddParameter("upload_phase", "start");
                initRequest.AddParameter("file_size", fileSize.ToString());

                var initResponse = client.Execute<FacebookInitUploadVideoRes>(initRequest);
                if (initResponse.IsSuccessful)
                {
                    if (initResponse.Data == null || initResponse.Data.upload_session_id == null)
                    {
                        response.OnError("Failed to initialize upload session.");
                        return response;
                    }

                }
                else
                {
                    var baseError = JsonConvert.DeserializeObject<FacebookBaseResponse>(initResponse.Content);
                    if (baseError != null)
                    {
                        if (baseError.error.Code == (int)FacebookErrorCode.InvalidOAuthAccessToken && isRetry)
                        {
                            var refreshTokenRes = await GetLongLiveAccessToken(param.AccessToken);
                            if (refreshTokenRes.Success && refreshTokenRes.Data != null)
                            {
                                var tokenData = (FacebookGetTokenResponse)refreshTokenRes.Data;
                                if (tokenData != null)
                                {
                                    param.AccessToken = tokenData.AccessToken;
                                    param.DataExtend = tokenData;

                                    return await UploadPageVideo<T>(param, false);
                                }

                            }

                        }
                    }
                    response.OnError((int)FacebookErrorCode.InvalidOAuthAccessToken);
                    return response;
                }

                string uploadSessionId = initResponse.Data.upload_session_id;
                string videoId = initResponse.Data.video_id;

                // Step 2: Upload Chunks
                using (MemoryStream ms = new MemoryStream(param.FileBytes))
                {
                    int chunkSize = 4 * 1024 * 1024;
                    chunkSize = Math.Min(chunkSize, fileSize);
                    byte[] buffer = new byte[chunkSize];
                    int bytesRead;
                    int startOffset = 0;

                    while ((bytesRead = ms.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        var uploadRequest = new RestRequest(Method.POST);
                        uploadRequest.AddParameter("access_token", param.AccessToken);
                        uploadRequest.AddParameter("upload_phase", "transfer");
                        uploadRequest.AddParameter("upload_session_id", uploadSessionId);
                        uploadRequest.AddParameter("start_offset", startOffset.ToString());
                        uploadRequest.AddFileBytes("video_file_chunk", buffer.Take(bytesRead).ToArray(), "chunk", "application/octet-stream");

                        var uploadResponse = client.Execute<FacebookUploadVideoRes>(uploadRequest);
                        if (uploadResponse.IsSuccessful)
                        {
                            if (uploadResponse.Data == null)
                            {
                                response.OnError("Lỗi upload file chunk video");
                                return response;
                            }

                            if (uploadResponse.Data.start_offset == null)
                            {
                                break;
                            }

                            startOffset = int.Parse(uploadResponse.Data.start_offset);

                            if (chunkSize <= fileSize - startOffset)
                            {
                                continue;
                            }
                            buffer = new byte[fileSize - startOffset];
                        }
                        else
                        {
                            response.OnError("Upload chunk file không thành công");
                            return response;
                        }
                    }
                }

                response.Data = new FacebookUploadVideoFinishRes()
                {
                    video_id = videoId,
                    upload_session_id = uploadSessionId
                };

                if (param.DataExtend != null)
                {
                    response.DataExtend = param.DataExtend;
                }
            }
            catch (Exception ex)
            {

                response.OnException(ex);
            }
            return response;

        }

        public async Task<string> UploadImage(string path, string token, string pageID)
        {
            var route = string.Format(FacebookEndpoint.UploadPhotoUnPublish, false.ToString());
            try
            {
                var bytes = File.ReadAllBytes(path);
                var param = new FBUploadFileParam<object>()
                {
                    AccessToken = token,
                    PageID = pageID,
                    FileBytes = bytes,
                    FileName = "ntvvu1",
                    FileType = "image/jpg"
                };
                var res = await UploadAttachment(param, route, Method.POST); //application/pdf, image/jpeg, image/jpg, image/png, and video/mp4
                dynamic id = res.Data;
                return id.id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PartnerApiResponse> UploadAttachment<T>(FBUploadFileParam<T> param, string route, Method method, bool isRetry = true)
        {
            var response = new PartnerApiResponse();
            try
            {
                string facebookGraphUrl = _facebookConfig.FacebookGraphUrl;
                var client = new RestClient(facebookGraphUrl);

                var request = new RestRequest(route, method);

                request.AddFileBytes("file", param.FileBytes, param.FileName, param.FileType);
                request.AddQueryParameter("access_token", param.AccessToken);
                request.AddParameter("access_token", param.AccessToken);
                var clientResponse = client.Execute<FBUploadAttachmentRes>(request);
                if (clientResponse.IsSuccessful)
                {
                    response.Data = clientResponse.Data;
                }
                else
                {
                    var baseError = JsonConvert.DeserializeObject<FacebookBaseResponse>(clientResponse.Content);
                    if (baseError != null)
                    {
                        if (baseError.error.Code == (int)FacebookErrorCode.InvalidOAuthAccessToken && isRetry)
                        {
                            var refreshTokenRes = await GetLongLiveAccessToken(param.AccessToken);
                            if (refreshTokenRes.Success && refreshTokenRes.Data != null)
                            {
                                var tokenData = (FacebookGetTokenResponse)refreshTokenRes.Data;
                                if (tokenData != null)
                                {
                                    param.AccessToken = tokenData.AccessToken;
                                    param.DataExtend = tokenData;

                                    return await UploadAttachment(param, route, method, false);
                                }

                            }

                        }
                    }
                    response.OnError((int)FacebookErrorCode.InvalidOAuthAccessToken);
                    return response;
                }
                if (param.DataExtend != null)
                {
                    response.DataExtend = param.DataExtend;
                }
            }
            catch (Exception ex)
            {

                response.OnException(ex);
            }
            return response;
        }

    }
}
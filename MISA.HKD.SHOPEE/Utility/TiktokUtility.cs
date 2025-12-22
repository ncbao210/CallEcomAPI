

using MISA.HKD.SHOPEE.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace MISA.HKD.SHOPEE.Utility
{
    public class TitkokTimeParam
    {
        public long create_time_ge { get; set; }
        public long create_time_lt { get; set; }
       
    }
    public class TiktokUtility
    {
        ////V2
        //public static string appScecret = "31f7be97c5a3c764579ff95b7823e0713758100d";
        //public static string appkey = "6ejj6nto57hma";
        //public static string appId = "7444122416937568056";

        // V1
        //public static string appScecret = "80d004d0237f1ca0c21f449fd8c9cc368378019b";
        //public static string appkey = "6eju081772mjo";
        //public static string appId = "7444435781517084472";

        public static string appScecret = "cea84f8e37d760f36ce3717e7992ab9451a4ebb9";
        public static string appkey = "6ai1htcu25h0c";
        public static string appId = "7298357768582317829";



        /// <summary>
        /// Ctor
        /// </summary>
        public TiktokUtility() { }

        public long GetTimeStamp()
        {
            long timestamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            return timestamp;
        }

        //public async Task<T> GetConfigValue<T>(string configName)
        //{
        //    var propertyInfo = _tiktokConfig.GetType().GetProperty(configName);
        //    if (propertyInfo != null)
        //    {
        //        T value = (T)propertyInfo.GetValue(_tiktokConfig);
        //        if (value == null)
        //        {
        //            //_loggerPartner.LogInformation($"khong get được {configName}");
        //        }
        //        return value;
        //    }
        //    else
        //    {
        //        //_loggerPartner.LogError($"Property {configName} not found in TiktokConfig");
        //        return default(T);
        //    }
        //}

        /// <summary>
        /// Lấy ra chuỗi sign của api
        /// </summary>
        /// <returns></returns>
        /// ntvu1 (16/08/24)
        public string GetSign(RestRequest request, Object body)
        {
            string sign = string.Empty;
            if (request != null)
            {
                string input = "";
                // Convert Parameters to a list and then use LINQ to filter
                var lstParams = request.Parameters
                    .Where(x => x.Type == ParameterType.QueryString && !x.Name.Equals("sign") && !x.Name.Equals("access_token"))
                    .OrderBy(x => x.Name)
                    .ToList();

                // build input from path
                input += request.Resource;
                // build input from parameters
                foreach (var item in lstParams)
                {
                    input += item.Name + item.Value;
                }
                // build input from body
                if (body != null)
                {
                    if (CheckAddBodyCallAPITikTok(request))
                    {
                        string bodyJson = JsonConvert.SerializeObject(body);
                        input += bodyJson;
                    }
                }
                // build from app_secret
                input = appScecret + input + appScecret;
                sign = GeneratorSHA256HMAC(input, appScecret);
            }
            return sign;
        }

        public async Task<PartnerApiResponse> GetShopInfo(TiktokBaseParam<object> accountParam)
        {

            accountParam.Route = TiktokEndpoints.GetAuthInforShop;
            accountParam.Method = Method.GET;

            PartnerApiResponse response = await CallTiktokAPI<object, TiktokGetShopInfoResponse>(accountParam);
            return response;
        }

        /// <summary>
        /// Check addbody to build sign tiktok
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool CheckAddBodyCallAPITikTok(RestRequest request)
        {
            var parameter = request.Parameters.FirstOrDefault(x => x.Type == ParameterType.HttpHeader && !string.IsNullOrEmpty(x.Name) && x.Name.Equals("content-type") && x.Value != null && x.Value.ToString() == "multipart/form-data");
            if (parameter == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// hash SHA256 HMAC
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GeneratorSHA256HMAC(string input, string key)
        {
            var apiKey = Encoding.UTF8.GetBytes(key);
            string hashString = "";
            using (HMACSHA256 hmac = new HMACSHA256(apiKey))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
                if (hash != null && hash.Length > 0)
                {
                    for (int i = 0; i < hash.Length; i++)
                    {
                        hashString += hash[i].ToString("X2").ToLower(); // hex format
                    }
                }
            }
            return hashString;
        }

        /// <summary>
        /// Build URl Tiktok
        /// </summary>
        /// <param name="route"></param>
        /// <param name="shop_cipher"></param>
        /// <returns></returns>
        /// ntvu1 16.8.2024
        private string BuildUrl(string route, string shop_cipher)
        {
            // Base url
            long timestamp = GetTimeStamp();
            //string tikTokAppKey = "6ejj6nto57hma";
            string baseUrl = TiktokConstants.Pathend;

            if (!string.IsNullOrEmpty(shop_cipher))
            {
                baseUrl = TiktokConstants.Pathend;
                baseUrl = String.Format(baseUrl, timestamp, appkey, shop_cipher);
            }
            else
            {
                baseUrl = TiktokConstants.PathendNoCipher;
                baseUrl = String.Format(baseUrl, timestamp, appkey);
            }


            // Kiểm tra xem route truyền vào đã có pathend chưa
            string[] listUrl = route.Split(TiktokConstants.SplitterParam);
            if (listUrl.Length > 1)
            {
                route = $"{listUrl[0]}{baseUrl}&{listUrl[1]}";
            }
            else
            {
                route += baseUrl;
            }
            // Lấy config version
            string version = "202309";
            // replace version của API
            route = route.Replace(TiktokConstants.VersionApiKey, version);
            return route;
        }


        /// <summary>
        /// Lấy access token của shop
        /// </summary>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> GetAccessToken(string authCode)
        {

            string endpoint = TiktokEndpoints.GetAuthInforUser;
            //string appScecret = "31f7be97c5a3c764579ff95b7823e0713758100d";
            //string appKey = "6ejj6nto57hma";
            string route = string.Format(endpoint, appkey, authCode, appScecret);

            TiktokBaseParam<object> param = new TiktokBaseParam<object>
            {
                Route = route,
                Method = Method.GET,
            };
            PartnerApiResponse partnerApiResponse = await CallTiktokAuthAPI<object, TiktokGetTokenResponse>(param);
            return partnerApiResponse;
        }
        /// <summary>
        /// Refresh token cho shop
        /// </summary>
        /// <returns></returns>
        /// ntvu1 (16/08/24)
        public async Task<PartnerApiResponse> RefreshToken<TBody>(TiktokBaseParam<TBody> refreshTokenParam)
        {
            PartnerApiResponse response = new PartnerApiResponse();

            if (refreshTokenParam != null && !string.IsNullOrEmpty(refreshTokenParam.RefreshToken))
            {
                TiktokBaseParam<TBody> param = JsonConvert.DeserializeObject<TiktokBaseParam<TBody>>(JsonConvert.SerializeObject(refreshTokenParam));

                string route = TiktokEndpoints.RefreshtokenSeller;
                //string appKey = "6ejj6nto57hma";
                string refreshToken = refreshTokenParam.RefreshToken;
                //string appSecret = "31f7be97c5a3c764579ff95b7823e0713758100d";

                param.Route = string.Format(route, appkey, refreshToken, appScecret);

                param.Method = Method.GET;
                response = await CallTiktokAuthAPI<TBody, TiktokRefreshTokenResponse>(param);
            }
            else
            {
                response.OnError($"Không có refreshTokenParam => {JsonConvert.SerializeObject(refreshTokenParam)}");
            }

            return response;
        }

        /// <summary>
        /// Call tiktok api url Auth, hàm call này ko build acess token
        /// </summary>
        /// <typeparam name="Body">Kiểu dữ liệu của body request</typeparam>
        /// <typeparam name="T">Kiểu dữ liệu data trong respone.data trả về</typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        /// ntvu1 17.8.2024
        public async Task<PartnerApiResponse> CallTiktokAuthAPI<TBody, T>(TiktokBaseParam<TBody> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();

            try
            {

                if (param != null)
                {
                    // Build route
                    string route = param.Route;
                    // Lấy config
                    string tiktokAPIUrl = "https://auth.tiktok-shops.com";

                    RestRequest request = new RestRequest(route, param.Method);
                    request.AddHeader("content-type", "application/json");

                    response = await ProcessCallTiktokAPI<TBody, T>(param, request, tiktokAPIUrl);
                }


            }
            catch (Exception ex)
            {
                response.OnException(ex);
                //_logge/*r*/Partner.LogError(ex, "Lỗi khi call api Tiktok Auth: ");
            }
            return response;
        }


        /// <summary>
        /// Hàm call chung API tiktok, hàm này sẽ build access token vào header, build route theo Shopciper truyền vào
        /// ntvu1 16.8.2024
        /// </summary>
        public async Task<PartnerApiResponse> CallTiktokAPI<TBody, T>(TiktokBaseParam<TBody> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();

            try
            {

                if (param != null)
                {
                    // Build route
                    string route = BuildUrl(param.Route, param.ShopCipher);
                    // Lấy config
                    string tiktokAPIUrl = "https://open-api.tiktokglobalshop.com";

                    RestRequest request = new RestRequest(route, param.Method);

                    // Xử lí nếu là request đăng file lên tiktok
                    if (param.IsUploadFile)
                    {
                        request.AddHeader("content-type", "multipart/form-data");

                        if (param.File != null)
                        {
                            using (var stream = new MemoryStream(param.File))
                            {
                                request.AddFile("file", stream.ToArray(), Guid.NewGuid().ToString());
                            }
                        }
                    }
                    else
                    {
                        request.AddHeader("content-type", "application/json");
                        if (param.Method != Method.GET && param != null)
                        {
                            request.AddJsonBody((object)param.Body);
                        }
                    }


                    if (!string.IsNullOrWhiteSpace(param.AccessToken))
                    {
                        request.AddHeader("x-tts-access-token", param.AccessToken);
                    }
                    else
                    {
                        response.OnError($"Không có AccessToken => {JsonConvert.SerializeObject(param)}");
                        return response;
                    }

                    // build sign sau khi tạo request xong
                    string sign = GetSign(request, param.Body);

                    request.AddQueryParameter("sign", sign);

                    // cal tiktok api
                    response = await ProcessCallTiktokAPI<TBody, T>(param, request, tiktokAPIUrl);
                }


            }
            catch (Exception ex)
            {
                response.OnException(ex);
                //_loggerPartner.LogError(ex, "Lỗi khi call api Tiktok: ");
            }
            return response;
        }

        private async Task<PartnerApiResponse> ProcessCallTiktokAPI<TBody, T>(TiktokBaseParam<TBody> param, RestRequest request, string tiktokAPIUrl)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            RestClient client = new RestClient(tiktokAPIUrl);
            IRestResponse clientResponse = client.Execute(request);

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
                    //_loggerPartner.LogWarning(responseLog);
                }
                else
                {
                    //_loggerPartner.LogInformation(clientResponse.Content);
                }


                if (!string.IsNullOrWhiteSpace(clientResponse.Content))
                {
                    TiktokBaseResponse<T> resutlTiktok = JsonConvert.DeserializeObject<TiktokBaseResponse<T>>(clientResponse.Content);

                    if (resutlTiktok != null)
                    {
                        if (resutlTiktok.code == 0 && resutlTiktok.message.Trim().ToLower() == "success")
                        {
                            response.Data = resutlTiktok;
                        }
                        else
                        {
                            //Đã force log ở trên rồi thì thôi ko log nữa
                            if (!logged)
                            {
                                //_loggerPartner.LogWarning(clientResponse.Content);
                            }
                            response = await ApplyResponseErrorTiktok(resutlTiktok, param);
                        }

                    }
                    else
                    {
                        //_loggerPartner.LogWarning($"Không thể parse dữ liệu trả về từ Tiktok {clientResponse.Content}");
                        response.OnError("Không thể parse dữ liệu trả về từ Tiktok");

                    }
                }
            }


            if (param.DataExtend != null)
            {
                response.DataExtend = param.DataExtend;
            }
            return response;
        }


        /// <summary>
        /// Handle Call tiktok error
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseData"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private async Task<PartnerApiResponse> ApplyResponseErrorTiktok<TBody, T>(TiktokBaseResponse<T> responseData, TiktokBaseParam<TBody> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            if (responseData != null)
            {
                response.Success = false;
                response.Code = responseData.code;
                response.Message = responseData.message;

                if (param.IsRefreshToken)
                {
                    return response;
                }
                if (response.Code == (int)1051001 || response.Code == (int)1051002 || (response.Message.Contains("access token") && response.Message.Contains("invalid")))
                {
                    PartnerApiResponse refreshTokenRes = await RefreshToken(param);
                    param.IsRefreshToken = true;
                    if (refreshTokenRes != null && refreshTokenRes.Success)
                    {

                        TiktokBaseResponse<TiktokRefreshTokenResponse> baseResponse = refreshTokenRes.Data as TiktokBaseResponse<TiktokRefreshTokenResponse>;
                        TiktokRefreshTokenResponse dataRefToken = baseResponse.data;
                        param.AccessToken = dataRefToken.access_token;
                        param.RefreshToken = dataRefToken.refresh_token;
                        if (param.DataExtend == null)
                        {
                            param.DataExtend = new TiktokDataExtend()
                            {
                                AccessToken = dataRefToken.access_token,
                                RefreshToken = dataRefToken.refresh_token,
                                AccessTokenExpireIn = new DateTime(dataRefToken.access_token_expire_in),
                                RefreshTokenExpireIn = new DateTime(dataRefToken.refresh_token_expire_in),
                            };
                        }
                        else
                        {
                            param.AccessToken = dataRefToken.access_token;
                            param.RefreshToken = dataRefToken.refresh_token;
                        }
                        return await CallTiktokAPI<TBody, T>(param);
                    }
                    else
                    {
                        return refreshTokenRes;
                    }
                }
                else
                {
                    //_loggerPartner.LogError($"Lỗi tiktok trả về => {JsonConvert.SerializeObject(responseData)}");
                    response.OnError($"Lỗi tiktok trả về => {responseData.code}, {responseData.message}");
                }

            }
            else
            {
                //_loggerPartner.LogError($"Gọi lên tiktok không thành công (null response)");
                response.OnError($"Gọi lên tiktok không thành công (null response)");
            }
            return response;
        }

        /// <summary>
        /// Lấy danh sách sản phẩm từ TikTok dựa trên các tham số tìm kiếm.
        /// </summary>
        /// <param name="param">Tham số tìm kiếm sản phẩm trên TikTok.</param>
        /// <returns>Phản hồi từ API TikTok chứa danh sách sản phẩm.</returns>
        /// ntvu1 19.8.2024
        public async Task<PartnerApiResponse> GetListProduct(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();

            string router = string.Format(TiktokEndpoints.SearchProducts, param.PageSize, param.ShopCipher, string.Empty);

            param.Method = Method.POST;
            param.Route = router;

            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }

        /// <summary>
        /// Lấy chi tiết một sản phẩm từ TikTok dựa trên ID sản phẩm.
        /// </summary>
        /// <param name="param">Tham số chứa ID sản phẩm và thông tin cần thiết khác.</param>
        /// <returns>Phản hồi từ API TikTok chứa chi tiết sản phẩm.</returns>
        /// ntvu1 19.8.2024
        public async Task<object> GetProductDetails(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            if (!string.IsNullOrEmpty(param.ID))
            {
                string router = string.Format(TiktokEndpoints.GetProduct, param.ID, false);

                param.Method = Method.GET;
                param.Route = router;
                PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
                return partnerApiResponse;

            }
            else
            {
                response.OnError("Không có ID product");
            }
            return response;
        }

        /// <summary>
        /// In đơn hàng tiktok
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> Printorder(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.GET;

            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }

        /// <summary>
        /// In đơn hàng tiktok
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> OrderDetail(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.GET;

            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }

        /// <summary>
        /// Đang kí in 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> ShipPackage(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.POST;

            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }

        /// <summary>
        /// lấy danh sách đơn chuyển hoàn tiktok
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> GetorderReturn(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.POST;

            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }


        /// <summary>
        /// lấy danh sách đơn chuyển hoàn tiktok
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> Getorders(TiktokBaseParam<TitkokTimeParam> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.POST;

            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<TitkokTimeParam, object>(param);
            return partnerApiResponse;
        }

        /// <summary>
        /// lấy danh sách đơn chuyển hoàn tiktok
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> GetStatementTransactions(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.GET;
            param.Route = string.Format(TiktokEndpoints.GetTransactionOrderOld, param.AccessToken, "202212", param.ID);
            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }

        /// <summary>
        /// lấy danh sách đơn chuyển hoàn tiktok
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> FinanceStatements(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.GET;
            //param.Route = string.Format(TiktokEndpoints.FinanceStatements);
            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }

        /// <summary>
        /// lấy danh sách đơn chuyển hoàn tiktok
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> GetStatementTransactionsNew(TiktokBaseParam<object> param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            //param.Method = Method.GET;
            //param.Route = string.Format(TiktokEndpoints.GetTransactionOrder,  param.ID);
            //param.Route = param.Route.Replace(TiktokConstants.VersionApiKey, "202501");
            PartnerApiResponse partnerApiResponse = await CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }
    }
}
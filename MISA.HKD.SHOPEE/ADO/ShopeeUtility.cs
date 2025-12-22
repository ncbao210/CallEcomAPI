using MISA.HKD.SHOPEE.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Channels;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using WebGrease;

namespace MISA.HKD.SHOPEE.ADO
{
    public class ShopeeUtility
    {

        protected ShopeeConfig _shopeeConfig;

        public ShopeeUtility()
        {
            _shopeeConfig = new ShopeeConfig();
        }

        private readonly bool isV2 = true;

        /// <summary>
        /// Lấy partnerID của shopee
        /// </summary>
        /// ndchien (15/08/24)
        public async Task<Int64> GetShopeePartnerID()
        {
            if (isV2)
            {
                return 2009822;
            }
            else
            {
                return 2004299;
            }
        }

        /// <summary>
        /// Lấy partnerID của shopee
        /// </summary>
        /// ndchien (15/08/24)
        public async Task<string> GetShopeePartnerKey()
        {
            if (isV2)
            {
                return "694268446b57477252686b695041477848756c5967694e414a454b744f47794a";
                ;
            }
            else
            {
                return "8def79734c542e3f5a5bbbe19789c73973b64c4cfb89a8ff90b62e57a46f0eb5";
                ;
            }
        }

        /// <summary>
        /// Lấy ra chuỗi sign của api
        /// </summary>
        /// <returns></returns>
        /// ndchien (15/08/24)
        public async Task<decimal> GetTimeStemp()
        {
            DateTime start = DateTime.Now;
            decimal timestamp = ((DateTimeOffset)start).ToUnixTimeSeconds();
            return timestamp;
        }

        /// <summary>
        /// Lấy ra chuỗi sign của api
        /// </summary>
        /// <returns></returns>
        /// ndchien (15/08/24)
        public async Task<string> GetSign(ShopeeBaseParam param)
        {

            string tmp_base_string = String.Format("{0}{1}{2}{3}{4}", param.objRequest.partner_id, param.Route, param.objRequest.timestamp, param.AccessToken, param.objRequest.shop_id);
            byte[] key = Encoding.UTF8.GetBytes(param.objRequest.partner_key);
            byte[] base_string = Encoding.UTF8.GetBytes(tmp_base_string);
            var hash = new HMACSHA256(key);
            byte[] tmp_sign = hash.ComputeHash(base_string);
            string sign = BitConverter.ToString(tmp_sign).Replace("-", "").ToLower();
            return sign;
        }

        /// <summary>
        /// Hàm dùng để call sang Shopee lấy dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        /// ndchien (15/08/24)
        public async Task<List<object>> GetItemList(ShopeeBaseParam param, List<object> listData, int offset = 0)
        {
            param.Method = Method.GET;
            var rs = await CallShopeeAPI<ShopeeBaseResponse>(param);
            if (rs?.Data != null)
            {
                var dataRes = JsonConvert.DeserializeObject<ShopeeBaseResponse>(JsonConvert.SerializeObject(rs?.Data));
                var dataPaging = JsonConvert.DeserializeObject<ShopeePaging>(JsonConvert.SerializeObject(dataRes?.response));
                listData.AddRange(dataPaging.item);
                if (dataPaging.has_next_page)
                {
                    offset = dataPaging.next_offset;
                    param.PathTension = $"&offset={offset}&page_size=50&item_status=SELLER_DELETE&item_status=NORMAL&item_status=REVIEWING&item_status=BANNED";
                    return await GetItemList(param, listData, offset);
                }
                
                return listData;
            }
            return null;
        }

        /// <summary>
        /// Hàm dùng để call sang Shopee lấy dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        /// ndchien (15/08/24)
        public async Task<PartnerApiResponse> CallShopeeAPI<T>(ShopeeBaseParam param) where T : ShopeeBaseResponse
        {
            PartnerApiResponse response = new PartnerApiResponse();
            try
            {
                ShopeeBaseRequest objRequest = param.objRequest;
                var shop_id = objRequest?.shop_id;
                if (objRequest == null)
                {
                    objRequest = new ShopeeBaseRequest();
                }

                if (objRequest?.shop_id == 0)
                {
                    objRequest.shop_id = param.ShopId;
                }
                if (param != null && !string.IsNullOrWhiteSpace(param.AccessToken) && objRequest != null && objRequest.shop_id > 0)
                {
                    var apiUrl = "https://partner.shopeemobile.com";
                    var client = new RestClient(apiUrl);
                    objRequest.partner_id = await GetShopeePartnerID();
                    objRequest.timestamp = await GetTimeStemp();
                    objRequest.partner_key = await GetShopeePartnerKey();

                    param.objRequest = objRequest;
                    objRequest.sign = await GetSign(param);
                    string route = param.Route;

                    string bodyJson = JsonConvert.SerializeObject(objRequest, new JsonSerializerSettings()
                    {
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                        DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffFFFFK",
                        NullValueHandling = NullValueHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });


                    string pathend = string.Format("?access_token={0}&partner_id={1}&shop_id={2}&sign={3}&timestamp={4}", param.AccessToken, objRequest.partner_id, objRequest.shop_id, objRequest.sign, objRequest.timestamp);
                    route += pathend;

                    if (param.Method == Method.GET)
                    {
                        route += param.PathTension.ToString();
                    }
                    var request = new RestRequest(route, param.Method);

                    if (param.Method == Method.POST)
                    {
                        request.AddJsonBody(objRequest);
                    }
                    request.AddHeader("content-type", "application/json");
                    var clientResponse = client.Execute(request);
                    response.Code = (int)clientResponse.StatusCode;
                    response.Message = clientResponse.ErrorMessage;

                    bool logged = false;

                    if (clientResponse.IsSuccessful)
                    {
                        if (!string.IsNullOrWhiteSpace(clientResponse.Content))
                        {
                            response.Data = JsonConvert.DeserializeObject<T>(clientResponse.Content);
                            //Case các mã lỗi shopee trả về
                            ShopeeBaseResponse responseData = (ShopeeBaseResponse)response.Data;
                            if (responseData != null && !string.IsNullOrWhiteSpace(responseData.error))
                            {
                                //Đã force log ở trên rồi thì thôi ko log nữa
                                if (!logged)
                                {
                                    //_loggerPartner.LogWarning(clientResponse.Content);
                                }
                                response = await ApplyResponseErrorShopee<T>(responseData, param);
                            }
                        }
                    }
                    else
                    {
                        response.Success = false;
                    }

                    if (param.DataExtend != null)
                    {
                        response.DataExtend = param.DataExtend;
                    }
                }
            }
            catch (Exception ex)
            {
                response.OnException(ex);
                //_loggerPartner.LogError(ex, "Lỗi khi call api Shopee: ");
            }
            return response;
        }

        /// <summary>
        /// Refresh token cho shop
        /// </summary>
        /// <returns></returns>
        /// ndchien (15/08/24)
        public async Task<PartnerApiResponse> RefreshToken(ShopeeBaseParam refreshTokenParam)
        {
            PartnerApiResponse apiResponse = new PartnerApiResponse();
            if (refreshTokenParam != null)
            {
                ShopeeBaseParam param = JsonConvert.DeserializeObject<ShopeeBaseParam>(JsonConvert.SerializeObject(refreshTokenParam));
                param.Route = _shopeeConfig.ShopeeEndPointsConfig.RefreshToken;
                param.Method = Method.POST;
                apiResponse = await CallShopeeAPI<RefreshTokenResponse>(param);
                if (apiResponse != null)
                {
                    refreshTokenParam.IsRefreshToken = true;
                    if (apiResponse.Success)
                    {
                        RefreshTokenResponse refreshTokenData = (RefreshTokenResponse)apiResponse.Data;
                        // Trả về mã code refresh token thành công, báo lại để lưu lại token, refresh token
                        apiResponse.OnSuccess(refreshTokenData, code: (int)Code.RefreshTokenShopeeSuccess);
                        return apiResponse;
                    }
                    apiResponse.OnError("Không thể RefreshToken Shopee");
                }
                apiResponse.OnError("Không thể call sang Shopee");
            }
            else
            {
                apiResponse.OnError("Không lấy được EcomAcount");
            }
            return apiResponse;
        }

        /// <summary>
        /// Xử lý lỗi khi call api shopee
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseShopee">Response call shopee</param>
        /// <param name="baseParam"></param>
        /// <returns></returns>
        /// ndchien (15/08/24)
        public async Task<PartnerApiResponse> ApplyResponseErrorShopee<T>(ShopeeBaseResponse responseShopee, ShopeeBaseParam baseParam) where T : ShopeeBaseResponse
        {
            PartnerApiResponse response = new PartnerApiResponse();
            response.Success = false;
            response.Message = responseShopee.message;

            if (
                responseShopee.error == ShopeeError.error_auth.ToString() &&
                (
                    (!responseShopee.message.Contains("refresh_token") && !responseShopee.message.Contains("refresh token")) ||
                    responseShopee.message.Contains("access_token")
                ) && !baseParam.IsRefreshToken

            )
            {
                PartnerApiResponse refreshTokenRes = await RefreshToken(baseParam);
                // Nếu refresh token thành công thực hiện gọi lại api lấy dữ liệu
                if (refreshTokenRes.Success && refreshTokenRes.Code == (int)Code.RefreshTokenShopeeSuccess)
                {
                    RefreshTokenResponse dataRefToken = refreshTokenRes.Data as RefreshTokenResponse;
                    baseParam.AccessToken = dataRefToken.access_token;
                    baseParam.RefreshToken = dataRefToken.refresh_token;
                    if (baseParam.DataExtend == null)
                    {
                        baseParam.DataExtend = new DataExtend()
                        {
                            AccessToken = dataRefToken.access_token,
                            RefreshToken = dataRefToken.refresh_token
                        };
                    }
                    else
                    {
                        baseParam.AccessToken = dataRefToken.access_token;
                        baseParam.RefreshToken = dataRefToken.refresh_token;
                    }
                    return await CallShopeeAPI<T>(baseParam);
                }
                else
                {
                    return refreshTokenRes;
                }
            }
            else if (responseShopee.error.Contains(ShopeeError.error_unknown.ToString()))
            {
                response.Code = (int)Code.Shopee_Error_Unknown;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_params.ToString()))
            {
                response.Code = (int)Code.Shopee_Error_Params;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_server.ToString()))
            {
                response.Code = (int)Code.Shopee_Error_Server;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_too_many_request.ToString()))
            {
                response.Code = (int)Code.Shopee_Error_Too_Many_Request;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_not_support.ToString()))
            {
                response.Code = (int)Code.Shopee_Error_Not_Support;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_inner_error.ToString()))
            {
                response.Code = (int)Code.Shopee_Error_Inner_Error;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_duplicate.ToString()))
            {
                response.Code = (int)Code.Shopee_Error_Duplicate;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_holiday_on_add_item.ToString()))
            {
                response.Code = (int)Code.Shopee_Vacation_Mode;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_invalid_logistic_info.ToString()))
            {
                response.Code = (int)Code.Shopee_Contain_Logistic;
            }
            else if (responseShopee.error.Contains(ShopeeError.error_param.ToString()))
            {

                if (!string.IsNullOrWhiteSpace(responseShopee.message))
                {
                    string msgShopee = responseShopee.message.Trim().ToLower();
                    if (msgShopee.Contains(PartnerConstants.SHOPEE_CONTAIN_INFO.ToString().Trim().ToLower()))
                    {
                        response.Code = (int)Code.Shopee_Error_Info;
                        if (msgShopee.Contains(PartnerConstants.SHOPEE_CONTAIN_ATTRIBUTE.ToString().Trim().ToLower()))
                        {
                            response.Code = (int)Code.Shopee_Error_Attribute;
                        }
                    }
                    else if (msgShopee.Contains(PartnerConstants.SHOPEE_CONTAIN_Image.ToString().Trim().ToLower()))
                    {
                        response.Code = (int)Code.Shopee_Error_Image;
                    }
                    else if (msgShopee.Contains(PartnerConstants.SHOPEE_CONTAIN_Logistic.ToString()))
                    {
                        response.Code = (int)Code.Shopee_Contain_Logistic;
                    }
                }
            }
            else if (responseShopee.error == PartnerConstants.ShopeeProductErrorBusi)
            {
                if (responseShopee.message.Contains(PartnerConstants.ShopeeErrorStockReserve))
                {
                    response.Code = (int)Code.Shopee_Error_Stock_Reserve;
                }
            }
            else
            {
                response.Code = (int)Code.Shopee_Error_Unknown;
            }
            return response;
        }
        /// <summary>
        /// Hàm sinh chuỗi token shopee
        /// </summary>
        /// <param name="apiRoute"></param>
        /// <param name="bodyJson"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public string GenerateShopeeApiToken(string apiRoute, string bodyJson, string secretKey)
        {
            string shopeeInternetAPIUrl = "https://partner.shopeemobile.com";
            string key = string.Format("{0}/{1}|{2}", shopeeInternetAPIUrl, apiRoute, bodyJson);
            return GeneratorSHA256HMAC(key, secretKey);
        }
        /// <summary>
        /// hàm sinh chuỗi mã hóa 256 có key
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GeneratorSHA256HMAC(string input, string key)
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
        /// hàm lấy thông tin của shop
        /// </summary>
        /// <param name="accountParam">Thông tin cần truyền lên để lấy thông tin của shop</param>
        /// <returns></returns>
        /// ndchien (15/08/24)
        public async Task<ShopeeGetShopInfoResponse> GetShopInfo(BaseEcomAccountParam accountParam)
        {

            ShopeeGetShopInfoResponse shopInfo = null;
            accountParam.Route = _shopeeConfig.ShopeeEndPointsConfig.GetShopInfor;
            accountParam.Method = Method.GET;

            PartnerApiResponse response = await CallShopeeAPI<ShopeeGetShopInfoResponse>(accountParam);

            if (response != null && response.Success && response.Data != null)
            {
                shopInfo = (ShopeeGetShopInfoResponse)response.Data;
            }
            return shopInfo;
        }

        public async Task<PartnerApiResponse> GetListOrderByTime(ShopeeGetOrderListParam param)
        {

            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();

            if (param != null)

            {

                string route = _shopeeConfig.ShopeeEndPointsConfig.GetAvailableSolutions;

                string pathtension = string.Format(_shopeeConfig.ShopeeEndPointsConfig.GetReturnListPathEnd, param.page_size, param.page_no, param.update_time_from, param.update_time_to);

                param.Route = route;

                param.PathTension = pathtension;

                param.Method = Method.GET;

                partnerApiResponse = await CallShopeeAPI<ShopeeBaseResponse>(param);

            }

            else
            {
                partnerApiResponse.OnError("Không có param call GetListOrderByTime");
            }

            return partnerApiResponse;

        }

        public async Task<PartnerApiResponse> DownloadShippingDocument(ShopeeBaseParam param, ShopeeGetShippingDocumentRequest request)
        {
            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();

            param.Method = Method.POST;
            param.objRequest = request;


            partnerApiResponse = await CallShopeeAPIDowload<ShopeeGetShippingDocumentRequest>(param);

            return partnerApiResponse;
        }
        /// <summary>
        /// Build common parameter của shopee theo đúng format của shopee
        /// </summary>
        /// <param name="isPublishAPI"></param>
        /// <param name="objRequest"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        /// ntvu1 21.8.2024
        private string GetCommonPathEnd(bool isPublishAPI, ShopeeBaseRequest objRequest, string accessToken)
        {
            string pathend = "";
            // Nếu là api publish thì không cần access token
            if (isPublishAPI)
            {
                pathend = string.Format("?partner_id={0}&timestamp={1}&sign={2}", objRequest.partner_id, objRequest.timestamp, objRequest.sign);
            }
            else
            {
                pathend = string.Format("?access_token={0}&partner_id={1}&shop_id={2}&sign={3}&timestamp={4}", accessToken, objRequest.partner_id, objRequest.shop_id, objRequest.sign, objRequest.timestamp);
            }
            return pathend;
        }
        /// <summary>
        /// API download file từ shopee (download ảnh giao hàng)
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        /// ntvu1 21.8.2024
        public async Task<PartnerApiResponse> CallShopeeAPIDowload<TBody>(ShopeeBaseParam param)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            try
            {
                if (
                    param != null &&
                    (param.objRequest != null &&
                    param.objRequest.shop_id > 0 &&
                    !string.IsNullOrWhiteSpace(param.AccessToken) || param.IsPublishAPI)
                )
                {
                    var objRequest = param.objRequest;
                    var objReqBody = JsonConvert.DeserializeObject<object>(JsonConvert.SerializeObject(param.objRequest));


                    objRequest.partner_id = await GetShopeePartnerID();
                    objRequest.timestamp = await GetTimeStemp();
                    objRequest.partner_key = await GetShopeePartnerKey();
                    objRequest.sign = await GetSign(param);
                    string route = param.Route;

                    string pathend = GetCommonPathEnd(param.IsPublishAPI, param.objRequest, param.AccessToken);

                    route += pathend;

                    if (param.Method == Method.GET)
                    {
                        route += param.PathTension.ToString();
                    }

                    var request = new RestRequest(route, param.Method);

                    if (param.Method == Method.POST)
                    {
                        request.AddJsonBody(objReqBody);
                    }
                    request.JsonSerializer = NewtonsoftJsonSerializer.Default;

                    request.AddHeader("content-type", "application/json");


                    byte[] buffer = null;
                    var client = new RestClient(_shopeeConfig.APIUrl);
                    try
                    {
                        buffer = client.DownloadData(request);
                    }
                    catch (WebException ex)
                    {
                        response.Success = false;
                        response.Message = "Lỗi webexception khi tải file shopee";
                    }
                    catch (Exception ex)
                    {

                        response.Success = false;
                        response.Message = "Lỗi tải file shopee trả về";
                    }

                    if (buffer == null || buffer.Length == 0)
                    {
                        // Không lấy được dữ liệu in
                        response.Success = false;
                        response.Message = "Không lấy được dữ liệu in";
                    }
                    else
                    {
                        response.Data = buffer;
                        response.Success = true;
                    }


                    // Nếu fail thì xử lý lỗi
                    if (!response.Success)
                    {
                        ShopeeBaseResponse dataRes = (ShopeeBaseResponse)response.Data;
                        if (dataRes != null)
                        {
                        }
                    }

                    if (param.DataExtend != null)
                    {
                        response.DataExtend = param.DataExtend;
                    }
                }
            }
            catch (Exception ex)
            {
                response.OnException(ex);
            }
            return response;
        }

        /// <summary>
        /// lây cách xử lý đơn chuyển hoàn
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> GetAvailableSolutionParam(AvailableSolutionParam param)
        {

            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();

            if (param != null)

            {

                param.Method = Method.GET;

                partnerApiResponse = await CallShopeeAPI<ShopeeBaseResponse>(param);

            }

            else
            {
                partnerApiResponse.OnError("Không có param call GetListOrderByTime");
            }

            return partnerApiResponse;

        }

        public async Task<PartnerApiResponse> GetOrderDetail(OrderDetailParam param)
        {

            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();

            if (param != null)

            {

                param.Method = Method.GET;

                partnerApiResponse = await CallShopeeAPI<ShopeeBaseResponse>(param);

            }

            else
            {
                partnerApiResponse.OnError("Không có param call GetListOrderByTime");
            }

            return partnerApiResponse;

        }
        public async Task<PartnerApiResponse> CreateShipping(CreateShipping param)
        {

            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();

            if (param != null)

            {

                param.Method = Method.POST;

                partnerApiResponse = await CallShopeeAPI<ShopeeBaseResponse>(param);

            }

            else
            {
                partnerApiResponse.OnError("Không có param call GetListOrderByTime");
            }

            return partnerApiResponse;

        }

    }
}
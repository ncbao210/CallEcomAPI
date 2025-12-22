using MISA.HKD.SHOPEE.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace MISA.HKD.SHOPEE
{
    public class AhamoveApi : BaseShippingPartnerUtilities
    {
        private readonly AhamoveConfig _ahamoveConfig;

        public AhamoveApi()
        {
            _ahamoveConfig = new AhamoveConfig();
        }

        /// <summary>
        /// Call api ahamove
        /// </summary>
        /// <typeparam name="TBody"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="method"></param>
        /// <param name="endPoint"></param>
        /// <param name="param"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<PartnerApiResponse> CallAhamoveApi<TBody, TResponse>(Method method, string endPoint, AhamoveBaseParam<TBody> param, Dictionary<string, string> parameters = null, string contentType = AhamoveConstants.AhamoveContentType.FormUrlEncoded)
        {
            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();
            if (param == null)
            {
                partnerApiResponse.OnError("Param is null");
                return partnerApiResponse;
            }

            try
            {
                RestClient client = new RestClient(_ahamoveConfig.ApiUrl);
                RestRequest request = new RestRequest(endPoint, method);

                if (method != Method.GET && param.Body != null)
                {
                    request.AddHeader("content-type", contentType);
                    if (contentType == AhamoveConstants.AhamoveContentType.FormUrlEncoded)
                    {
                        request.AddHeader("accept", "application/json");
                        var bodyParam = ToDictionaryFromJsonProperties(param.Body);
                        foreach (var item in bodyParam)
                        {
                            request.AddParameter(item.Key, item.Value);
                        }
                    }
                    else if (contentType == AhamoveConstants.AhamoveContentType.JsonBody)
                    {
                        request.AddJsonBody(param.Body);
                    }


                }
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        request.AddQueryParameter(item.Key, item.Value);
                    }
                    request.AddQueryParameter("api_key", _ahamoveConfig.ApiKey);
                }
                if (!string.IsNullOrEmpty(param.Token))
                {
                    request.AddParameter("token", param.Token);
                    request.AddQueryParameter("token", param.Token);
                }

                IRestResponse response = await client.ExecuteAsync(request);

                if (response != null)
                {
                    if (response.IsSuccessful)
                    {
                        TResponse data = JsonConvert.DeserializeObject<TResponse>(response.Content);
                        if (data != null)
                        {
                            partnerApiResponse.OnSuccess(data);
                        }
                        else
                        {
                            partnerApiResponse.OnError("Parse data error!", response.Content, (int)response.StatusCode);
                        }
                    }
                    else
                    {
                        partnerApiResponse.OnError("Request failed!", response.ErrorMessage, (int)response.StatusCode);
                    }
                }
                else
                {
                    partnerApiResponse.OnError("Response is null");
                }
            }
            catch (Exception ex)
            {
                partnerApiResponse.OnException(ex);
            }
            return partnerApiResponse;
        }

        /// <summary>
        /// Đăng ký tài khoản mới hoặc cập nhật thông tin tài khoản nếu đã tồn tại trên hệ thống Ahamove.
        /// ntvu1 12.9.2024
        /// </summary>
        /// <param name="param">Tham số đầu vào để đăng ký hoặc cập nhật tài khoản.</param>
        /// <returns>Phản hồi từ API sau khi đăng ký hoặc cập nhật tài khoản.</returns>
        public async Task<PartnerApiResponse> RegisterAccount()
        {
            var endPoint = AhamoveEndpoints.SignIn;
            var param = new AhamoveBaseParam<object>();
            var queries = new Dictionary<string, string>()
            {
                {"mobile", "0397593863" }
            };
            return await CallAhamoveApi<object, object>(Method.GET, endPoint, param, queries);
        }
    }
}
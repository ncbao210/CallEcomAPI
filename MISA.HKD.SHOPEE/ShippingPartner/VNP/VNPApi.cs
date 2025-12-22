using MISA.HKD.SHOPEE.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class VNPApi : BaseShippingPartnerUtilities
    {
        private readonly VNPConfig _vnpConfig;

        public VNPApi()
        {
            _vnpConfig = new VNPConfig();
        }

        public async Task<PartnerApiResponse> CallVNPApi<TParam, TResponse>(Method method, string url, VNPBaseParam<TParam> param, Dictionary<string, object> paramaters = null)
        {
            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();
            if (param == null)
            {
                partnerApiResponse.OnError("Param is null");
                return partnerApiResponse;
            }
            try
            {
                var client = new RestClient(_vnpConfig.ApiUrl);

                var request = new RestRequest(url, method);

                if (!string.IsNullOrEmpty(param.Token))
                {
                    request.AddHeader("token", param.Token);
                }

                if (param.Body != null)
                {
                    request.AddJsonBody(param.Body);
                }
                if (paramaters != null)
                {
                    foreach (var item in paramaters)
                    {
                        request.AddParameter(item.Key, item.Value);
                    }
                }

                var response = await client.ExecuteAsync(request);
                if (response != null)
                {
                    if (response.IsSuccessful)
                    {
                        var data = JsonConvert.DeserializeObject<TResponse>(response.Content);
                        if (data != null)
                        {
                            partnerApiResponse.OnSuccess(data);
                        }
                        else
                        {
                            partnerApiResponse.OnError("Parse data failed", response.Content, (int)response.StatusCode);
                        }
                    }
                    else
                    {
                        partnerApiResponse.OnError("Response is not successful", response.Content, (int)response.StatusCode);
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
        /// Lấy token truy cập từ hệ thống VNP.
        /// </summary>
        /// <param name="param">Tham số cần thiết để lấy token truy cập.</param>
        /// <returns>Phản hồi từ API về token truy cập.</returns>
        /// ntvu1 12.9.2024
        public async Task<PartnerApiResponse> GetAccessToken()
        {
            var endPoint = VNPEndPoints.GetAccessToken;
            var param = new VNPBaseParam<object>()
            {
                Body = new
                {
                    username = "0397593863",
                    password = "12346578@Abc",
                    customerCode = "C015757627"
                }
            };
            return await CallVNPApi<object, object>(Method.POST, endPoint, param);
        }
    }
}
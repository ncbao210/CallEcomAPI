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
    public class GHNApi : BaseShippingPartnerUtilities
    {
        private readonly GHNConfig _GHNConfig;

        public GHNApi()
        {
            _GHNConfig = new GHNConfig();
        }

        /// <summary>
        /// Gọi API của GHN.
        /// </summary>
        /// <typeparam name="TParam">Kiểu dữ liệu của tham số gửi đi.</typeparam>
        /// <typeparam name="TResponse">Kiểu dữ liệu của phản hồi nhận về.</typeparam>
        /// <param name="method">Phương thức HTTP sử dụng (GET, POST, ...).</param>
        /// <param name="endpoint">Điểm cuối của API cần gọi.</param>
        /// <param name="param">Tham số gửi đi trong yêu cầu.</param>
        /// <returns>Kết quả phản hồi từ GHN.</returns>
        /// ntvu1 12.9.2024
        public async Task<PartnerApiResponse> CallGHNApi<TParam, TResponse>(Method method, string endpoint, GHNBaseParam<TParam> param)
        {
            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();
            if (param == null)
            {
                partnerApiResponse.OnError("Param is null");
                return partnerApiResponse;
            }

            try
            {
                RestClient client = new RestClient(_GHNConfig.ApiUrl);
                RestRequest request = new RestRequest(endpoint, method);

                if (param.Token != null)
                {
                    request.AddHeader("token", param.Token);
                }
                if (param.ShopId != null)
                {
                    request.AddHeader("shopid", param.ShopId);
                }

                if (param.Body != null)
                {
                    request.AddJsonBody(param.Body);
                    //var paramsss = ToDictionaryStringFromJsonProperties(param.Body);
                    //foreach (var item in paramsss)
                    //{
                    //    request.AddParameter(item.Key, item.Value);
                    //}
                }

                IRestResponse response = await client.ExecuteAsync(request);

                if (response != null)
                {
                    if (response.IsSuccessful)
                    {
                        var data = JsonConvert.DeserializeObject<TResponse>(response.Content);
                        if (data != null)
                        {
                            partnerApiResponse.OnSuccess(data, response.ErrorMessage, (int)response.StatusCode);
                        }
                        else
                        {
                            partnerApiResponse.OnError("Parse to object failed", response.Content, (int)response.StatusCode);
                        }
                    }
                    else
                    {
                        partnerApiResponse.OnError("Request failed", response.Content, (int)response.StatusCode);

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

        public async Task<PartnerApiResponse> CreateOrder()
        {
            string token = "d6b8de3f-71ac-11ef-8e53-0a00184fe694";
            var endpoint = GHNEndpoints.CreateOrder;

            var param = new GHNBaseParam<object>()
            {
                ShopId = "194466",
                Token = token,
                Body = new
                {
                    payment_type_id = 2,
                    note = "Tintest 123",
                    required_note = "KHONGCHOXEMHANG",
                    from_name = "TinTest124",
                    from_phone = "0987654321",
                    from_address = "72 Thành Thái, Phường 14, Quận 10, Hồ Chí Minh, Vietnam",
                    from_ward_name = "Phường 14",
                    from_district_name = "Quận 10",
                    from_province_name = "HCM",
                    return_phone = "0332190444",
                    return_address = "39 NTT",

                    return_ward_code = "",
                    client_order_code = "",
                    to_name = "TinTest124",
                    to_phone = "0987654321",
                    to_address = "72 Thành Thái, Phường 14, Quận 10, Hồ Chí Minh, Vietnam",
                    to_ward_code = "20308",
                    to_district_id = 1444,
                    cod_amount = 200000,
                    content = "Theo New York Times",
                    weight = 200,
                    length = 1,
                    width = 19,
                    height = 10,
                    pick_station_id = 1444,

                    insurance_value = 46000,
                    service_id = 0,
                    service_type_id = 2,

                    pick_shift = new List<int>() { 2 },
                    items = new List<object>() { new {
                    name = "Áo Polo",
                    code = "Polo123",
                    quantity = 1,
                    price = 200000,
                    length = 12,
                    width = 12,
                    height = 12,
                    weight = 1200,
                    category = new {
                    level1 = "Áo"
                }
                    }
                }
                }
            };

            return await CallGHNApi<object, object>(Method.POST, endpoint, param);
        }


        public async Task<PartnerApiResponse> PrintOrder()
        {
            var endpoint = GHNEndpoints.GetTokenPrintOrder;
            string token = "d6b8de3f-71ac-11ef-8e53-0a00184fe694";
            var param = new GHNBaseParam<object>
            {
                Token = token,
                Body = new
                {
                    order_codes = new List<string>() { "LNT7U6" },
                    OrderCodes = new List<string>() { "LNT7U6" }
                }
            };

            return await CallGHNApi<object, object>(Method.POST, endpoint, param);
        }

        public async Task<PartnerApiResponse> GetOrderInfo()
        {
            var endpoint = GHNEndpoints.OrderInfo;
            string token = "d6b8de3f-71ac-11ef-8e53-0a00184fe694";
            string shopID = "194466";
            var param = new GHNBaseParam<object>
            {
                Token = token,
                ShopId = shopID,
                Body = new
                {
                    order_code = "LNT7U6"
                }
            };

            return await CallGHNApi<object, object>(Method.POST, endpoint, param);
        }
    }
}
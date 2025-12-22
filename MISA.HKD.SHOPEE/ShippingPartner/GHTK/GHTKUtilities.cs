using MISA.HKD.SHOPEE.Models;
using MISA.HKD.SHOPEE.ShippingPartner.Endpoints;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class GHTKUtilities : BaseShippingPartnerUtilities
    {
        private readonly GHTKConfig _GHTKConfig;

        public GHTKUtilities()
        {
            _GHTKConfig = new GHTKConfig();
        }

        /// <summary>
        /// Gọi API của GHTK với các tham số đầu vào cụ thể.
        /// </summary>
        /// <typeparam name="TParam">Kiểu dữ liệu của tham số đầu vào.</typeparam>
        /// <typeparam name="TResponse">Kiểu dữ liệu mong muốn nhận về từ API.</typeparam>
        /// <param name="method">Phương thức HTTP sử dụng cho lời gọi API (GET, POST, ...).</param>
        /// <param name="url">URL của API cần gọi.</param>
        /// <param name="param">Tham số đầu vào cho API.</param>
        /// <param name="queryParameters">Các tham số truy vấn (nếu có).</param>
        /// <returns>Phản hồi từ API dưới dạng <see cref="PartnerApiResponse"/>.</returns>
        /// ntvu1 11.9.2024
        public async Task<PartnerApiResponse> CallGHTKApi<TParam, TResponse>(Method method, string url, GHTKBaseParam<TParam> param, Dictionary<string, string> queryParameters = null)
        {
            PartnerApiResponse response = new PartnerApiResponse();
            if (param == null)
            {
                response.OnError("Param is null");
                return response;
            }

            try
            {
                RestClient client = new RestClient(_GHTKConfig.ApiUrl);

                RestRequest request = new RestRequest(url, method);

                if (!string.IsNullOrEmpty(param.Token))
                {
                    request.AddHeader("Token", param.Token);
                }
                //LDNGOC 18.03.2019: Nếu truyền X-Refer-Token thì order được tạo sẽ nhận callback theo URL của partner account (MISA) → Sai CompanyCode
                //request.AddHeader("X-Refer-Token", _GHTKConfig.Token);

                if (method != Method.GET && param.Body != null)
                {
                    request.AddJsonBody(param.Body);
                }

                if (queryParameters != null)
                {
                    foreach (var queryParameter in queryParameters)
                    {
                        request.AddQueryParameter(queryParameter.Key, queryParameter.Value);
                    }
                }

                var restResponse = await client.ExecuteAsync(request);
                if (restResponse != null)
                {
                    if (restResponse.IsSuccessful)
                    {

                        var dataResponse = JsonConvert.DeserializeObject<TResponse>(restResponse.Content);
                        if (dataResponse != null)
                        {
                            response.OnSuccess(dataResponse);
                        }
                        else
                        {
                            response.OnError("Parse data failed", restResponse.Content, (int)restResponse.StatusCode);
                        }
                    }
                    else
                    {
                        response.OnError(restResponse.ErrorMessage, restResponse.Content, (int)restResponse.StatusCode);
                    }
                }
                else
                {
                    response.OnError("Response is null");
                }
            }
            catch (Exception ex)
            {

                response.OnException(ex);
            }
            return response;
        }

        public async Task<PartnerApiResponse> GetAddress(string token)
        {
            var param = new GHTKBaseParam<object>() { Token = token };

            return await CallGHTKApi<object, object>(Method.GET, GHTKEndpoints.GetListPickAdd, param);

        }

        public async Task<PartnerApiResponse> CreateOrder(string token)
        {
            var param = new GHTKBaseParam<object>()
            {
                Token = token,
                Body = new GHTKCreateOrderBody()
                {
                    Order = new GHTKOrder()
                    {
                        //"deliver_option" : "xteam", // nếu lựa chọn kiểu vận chuyển xfast    
                        //"pick_session" : 2 // Phiên lấy xfast 
                        Id = Guid.NewGuid().ToString(),
                        Note = "Khối lượng tính cước tối đa: 1.00 kg",
                        PickDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        IsFreeship = 0,
                        DeliverOption = "xteam",
                        PickSession = 2,
                        Value = 3000000,
                        WeightOption = "1200",
                        TotalWeight = 34000,
                        Transport = "road", //Đối với GHTK thì ServiceID chính là TransportMethod (road|fly)
                        PickOption = "cod",
                        PickrWorkShift = 2,

                        //From
                        Address = "123 nguyễn chí thanh",
                        Province = "TP. Hồ Chí Minh",
                        District = "Quận 1",
                        Ward = "Phường Bến Nghé",
                        Name = "GHTK - HCM - Noi Thanh",
                        Tel = "0911222333",

                        //To
                        PickName = "HCM-nội thành",
                        PickTel = "0911222333",
                        PickDistrict = "Quận 3",
                        PickProvince = "TP. Hồ Chí Minh",
                        PickWard = "Phường 1",
                        PickAddress = "590 CMT8 P.11",
                        PickMoney = 47000,

                        //Return
                        UseReturnAddress = 0,
                        ReturnTel = "0397593863",
                        ReturnEmail = "vunguyenaz1309@gmail.com",
                        Hamlet = "Khác",
                        Tags = new List<GHTKTag>() { GHTKTag.DeVo },

                    },

                    Products = new List<GHTKProduct> { new GHTKProduct() {
                     Name = "bút",
                         //Price = 12000,
                         Weight = 0.1,
                         Quantity = 1,
                         ProductCode = 1241
                    } }
                }

            };

            return await CallGHTKApi<object, object>(Method.POST, GHTKEndpoints.CreateOrder, param);

        }


        public async Task<PartnerApiResponse> PrintOrder(string token)
        {
            var param = new GHTKBaseParam<object>()
            {
                Token = token
            };
            string endpoint = $"{GHTKEndpoints.PrintOrderInfo}S1.8663516";

            return await CallGHTKApi<object, object>(Method.GET, endpoint, param);
        }

    }
}
using MISA.HKD.SHOPEE.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace MISA.HKD.SHOPEE
{
    public class VTPApi : BaseShippingPartnerUtilities
    {
        private readonly VTPConfig _VTPConfig;

        public VTPApi()
        {
            _VTPConfig = new VTPConfig();
        }

        /// <summary>
        /// Hàm call api chung lên Viettelpost
        /// </summary>
        /// <typeparam name="TBody">Kiểu dữ liệu của body</typeparam>
        /// <typeparam name="TResponse">Kiểu dữ liệu phản hồi</typeparam>
        /// <param name="method">Phương thức</param>
        /// <param name="url">Endpoint</param>
        /// <param name="param"></param>
        /// <returns></returns>
        /// ntvu1 11.9.2024
        public async Task<PartnerApiResponse> CallVTPAPI<TBody, TResponse>(Method method, string url, VTPBaseParam<TBody> param)
        {
            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();
            if (param != null)
            {
                try
                {
                    RestClient client = new RestClient(_VTPConfig.ApiUrl);

                    RestRequest request = new RestRequest(url, method);

                    if (param.Token != null)
                    {
                        request.AddHeader("Token", param.Token);
                    }

                    if (method != Method.GET && param.Body != null)
                    {
                        request.AddJsonBody(param.Body);
                    }

                    IRestResponse response = await client.ExecuteAsync(request);

                    if (response != null)
                    {
                        if (response.IsSuccessful)
                        {

                            var dataRes = JsonConvert.DeserializeObject<VTPBaseResponse<TResponse>>(response.Content);
                            if (dataRes == null)
                            {
                                partnerApiResponse.OnError("Parse data failed", response.Content);
                            }
                            else
                            {
                                if (dataRes.error == false)
                                {
                                    partnerApiResponse.OnSuccess(dataRes);
                                }
                                else
                                {
                                    partnerApiResponse.OnError("Request failed", dataRes);
                                }
                            }
                        }
                        else
                        {
                            partnerApiResponse.OnError(response.Content);
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
            }
            else
            {
                partnerApiResponse.OnError("Param is null");
            }
            return partnerApiResponse;
        }


        /// <summary>
        /// Đăng nhập bằng tài khoản đối tác. Gửi yêu cầu đăng nhập đến Viettelpost sử dụng tài khoản đối tác.
        /// </summary>
        /// <param name="param">Tham số đầu vào cho việc đăng nhập</param>
        /// <returns>Phản hồi từ API</returns>
        /// ntvu1 11.9.2024
        public async Task<PartnerApiResponse> SignInByPartnerAccount()
        {
            PartnerApiResponse partnerApiResponse = new PartnerApiResponse();
            string url = VTPEndpoints.Login;

            var request = new
            {
                USERNAME = _VTPConfig.Email,
                PASSWORD = _VTPConfig.Password
            };
            partnerApiResponse = await CallVTPAPI<object, object>(Method.POST, url, new VTPBaseParam<object> { Body = request });

            return partnerApiResponse;
        }

        public async Task<PartnerApiResponse> GetListService(string token)
        {
            string url = VTPEndpoints.ListService;
            var param = new VTPBaseParam<object>
            {
                Token = token,
                Body = new
                {
                    TYPE = 2
                }
            };

            return await CallVTPAPI<object, object>(Method.POST, url, param);

        }

        public async Task<PartnerApiResponse> ListStore(string token)
        {
            var param = new VTPBaseParam<object>
            {
                Token = token,
                
            };

            return await CallVTPAPI<object, object>(Method.GET, VTPEndpoints.ListInventory, param);
        }
        public async Task<PartnerApiResponse> CreateNewStore(string token)
        {
            var param = new VTPBaseParam<object>
            {
                Token = token,
                Body = new
                {
                    PHONE = "0397593863",
                    NAME = "ntvu1 test",
                    ADDRESS = "61 K2 Cầu Diễn",
                    WARDS_ID = 493
                }
            };

            return await CallVTPAPI<object, object>(Method.POST, VTPEndpoints.CreateStore, param);
        }

        public async Task<PartnerApiResponse> CreateBill(string token)
        {
            var param = new VTPBaseParam<object>
            {
                Token = token,
                Body = new
                {
                    ORDER_NUMBER = Guid.NewGuid().ToString(),
                    GROUPADDRESS_ID = 19859242,
                    CUS_ID = 8341929,
                    DELIVERY_DATE = "11/10/2018 15:09:52",
                    SENDER_FULLNAME = "Yanme Shop",
                    SENDER_ADDRESS = "Số 5A ngách 22 ngõ 282 Kim Giang, Đại Kim (0967.363.789), Quận Hoàng Mai, Hà Nội",
                    SENDER_PHONE = "0967.363.789",
                    SENDER_EMAIL = "vanchinh.libra@gmail.com",
                    SENDER_WARD = 0,
                    SENDER_DISTRICT = 4,
                    SENDER_PROVINCE = 1,
                    SENDER_LATITUDE = 0,
                    SENDER_LONGITUDE = 0,
                    RECEIVER_FULLNAME = "Hoàng - Test",
                    RECEIVER_ADDRESS = "1 NKKN P.Nguyễn Thái Bình, Quận 1, TP Hồ Chí Minh",
                    RECEIVER_PHONE = "0907882792",
                    RECEIVER_EMAIL = "hoangnh50@fpt.com.vn",
                    RECEIVER_WARD = 0,
                    RECEIVER_DISTRICT = 43,
                    RECEIVER_PROVINCE = 2,
                    RECEIVER_LATITUDE = 0,
                    RECEIVER_LONGITUDE = 0,
                    PRODUCT_NAME = "Máy xay sinh tố Philips HR2118 2.0L ",
                    PRODUCT_DESCRIPTION = "Máy xay sinh tố Philips HR2118 2.0L ",
                    PRODUCT_QUANTITY = 1,
                    PRODUCT_PRICE = 210000,
                    PRODUCT_WEIGHT = 40000,
                    PRODUCT_LENGTH = 38,
                    PRODUCT_WIDTH = 24,
                    PRODUCT_HEIGHT = 25,
                    PRODUCT_TYPE = "HH",
                    ORDER_PAYMENT = 3,
                    ORDER_SERVICE = "VCN",
                    ORDER_SERVICE_ADD = "",
                    ORDER_VOUCHER = "",
                    ORDER_NOTE = "cho xem hàng, không cho thử",
                    MONEY_COLLECTION = 210000,
                    MONEY_TOTALFEE = 0,
                    MONEY_FEECOD = 0,
                    MONEY_FEEVAS = 0,
                    MONEY_FEEINSURRANCE = 0,
                    MONEY_FEE = 0,
                    MONEY_FEEOTHER = 0,
                    MONEY_TOTALVAT = 0,
                    MONEY_TOTAL = 0,
                    LIST_ITEM = new List<object>() {
                        new
                        {
                            PRODUCT_NAME = "Máy xay sinh tố Philips HR2118 2.0L ",
                        PRODUCT_PRICE = 210000,
                        PRODUCT_WEIGHT = 2500,
                        PRODUCT_QUANTITY = 1
                        }
                    }


                }
            };

            return await CallVTPAPI<object, object>(Method.POST, VTPEndpoints.CreateOrder, param);
        }

    }
}
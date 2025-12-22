using MISA.HKD.SHOPEE.ADO;
using MISA.HKD.SHOPEE.Models;
using MISA.HKD.SHOPEE.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MISA.HKD.SHOPEE.Controllers
{
    public class ShopeeController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("getavailable")]
        public async Task<object> GetAvailableSolutions([FromBody] AvailableSolutionParam param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            var rs = await shopeeUitlity.GetAvailableSolutionParam(param);

            return rs.Data;
        }

        [HttpPost]
        [Route("getreturndetail")]
        public async Task<object> GetReturnDetail([FromBody] AvailableSolutionParam param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            var rs = await shopeeUitlity.GetAvailableSolutionParam(param);

            return rs.Data;
        }
        [HttpPost]
        [Route("orderdetail")]
        public async Task<object> GetROrderDetail([FromBody] OrderDetailParam param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            var rs = await shopeeUitlity.GetOrderDetail(param);

            return rs.Data;
        }

        [HttpPost]
        [Route("printorder")]
        public async Task<object> PrintAPI([FromBody] DownloadOrderRequest param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            ShopeeGetShippingDocumentRequest request = new ShopeeGetShippingDocumentRequest();
            request.order_list = param.order_list;
            request.shop_id = param.shop_id;
            ShopeeBaseParam parameter = new ShopeeBaseParam();
            parameter.ShopId = param.shop_id;
            parameter.PathTension = param.PathTension;
            parameter.IsPublishAPI = param.IsPublishAPI;
            parameter.Method = Method.POST;
            parameter.AccessToken = param.AccessToken;
            parameter.Route = param.Route;


            return await shopeeUitlity.DownloadShippingDocument(parameter, request);

        }

        /// <summary>
        /// Đăng kí in đơn hàng
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createShipping")]
        public async Task<object> CreateShipping([FromBody] CreateShipping param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            OrderCreate a = new OrderCreate();
            a.order_list = (List<OrderShopee>)param.order_list;
            param.objRequest = a;
            param.objRequest.shop_id = param.ShopId;
            var rs = await shopeeUitlity.CreateShipping(param);

            return rs.Data;

        }

        /// <summary>
        /// Api lấy bất kỳ
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("call-get-any-shopee")]
        public async Task<object> CreateShipping([FromBody] ShopeeBaseParam param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            param.Method = Method.GET;
            var rs = await shopeeUitlity.CallShopeeAPI<ShopeeBaseResponse>(param);

            return rs.Data;

        }

        /// <summary>
        /// Api lấy bất kỳ
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("call-get-post-shopee")]
        public async Task<object> CallPostAnyShopee([FromBody] ShopeeBaseParam param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            param.Method = Method.POST;
            param.objRequest.refresh_token = param.RefreshToken;
            param.objRequest.shop_id = param.ShopId;
            var rs = await shopeeUitlity.CallShopeeAPI<ShopeeBaseResponse>(param);

            return rs.Data;

        }

        /// <summary>
        /// Api lấy bất kỳ
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get_buyer_invoice_info")]
        public async Task<object> GetBuyerInvoiceInfo([FromBody] GetBuyerInvoiceInfoParam param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            param.Method = Method.POST;
            GetBuyerInvoiceInfoRequest a = new GetBuyerInvoiceInfoRequest();
            a.queries = param.queries;
            param.objRequest = a;
            param.objRequest.shop_id = param.ShopId;
            param.objRequest.refresh_token = param.RefreshToken;
            var rs = await shopeeUitlity.CallShopeeAPI<ShopeeBaseResponse>(param);

            return rs.Data;

        }

        /// <summary>
        /// Api lấy bất kỳ
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get_item_list")]
        public async Task<IHttpActionResult> GetItemList([FromBody] ShopeeBaseParam param)
        {
            ShopeeUtility shopeeUitlity = new ShopeeUtility();
            param.Method = Method.POST;

            var listData = new List<object>();
            var rs = await shopeeUitlity.GetItemList(param, listData);
            return Ok(rs);

        }
    }
}

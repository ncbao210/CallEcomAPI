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
using System.Web.Http.Controllers;

namespace MISA.HKD.SHOPEE.Controllers
{
    public class TiktokController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("GetProduct")]
        public async Task<object> GetProduct(string accessToken, string refreshToken, string shopCipher, long id)
        {
            TiktokUtility tiktokUtility = new TiktokUtility();
            var param = new TiktokBaseParam<object>();
            if (id == 0)
            {
                param = new TiktokBaseParam<object>()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ShopCipher = shopCipher,
                    PageSize = 100,
                    Body = new
                    {
                        status = "ACTIVATE"
                    }
                };
                return (await tiktokUtility.GetListProduct(param));
            }
            else
            {
                param = new TiktokBaseParam<object>()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ShopCipher = shopCipher,
                    ID = id.ToString()
                };
                return (await tiktokUtility.GetProductDetails(param));
                
            }
        }

        // GET api/values/5
        [HttpPost]
        [Route("SearchProduct")]
        public async Task<string> SearchProduct(string id)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();
            var listData = new List<object>();
            var listId = new List<string>() { "1731747600900655181", "1731603675060275277", "1731603398119098445", "1731603178883811405", "1731421712537126989", "1731379287222028365", "1731201939158960205", "1731047109943593037", "1731023363248130125", "1731004781005473869", "1731002053645404237", "1730967219348211789", "1730791381883258957", "1730791380237387853", "1730791337737750605", "1730791277097879629", "1730791276610553933", "1730791379255461965", "1730791379161679949", "1730791335330482253", "1730791275978590285", "1730791332002236493", "1730791332044048461", "1730791271049365581", "1730791267714304077", "1730791348972456013", "1730791197283354701", "1730791037065070669", "1730791063533946957", "1730791014451021901", "1730755860815120461", "1730492848998680653", "1730352183550576717", "1730352164298000461", "1730350566509021261", "1730344780730042445", "1730344776593541197", "1730344758600960077", "1730245966250412109", "1730245947016841293", "1730245890214561869", "1730012848709273677", "1730004403553470541", "1729927492685563981", "1729885878376171597", "1729885860520953933", "1729885842320164941", "1729851808817317965", "1729752659842861133", "1729752629947566157", "1729752596597344333", "1729701927457032269", "1729701917875669069", "1729701910664153165", "1729701902938441805", "1729701884858894413", "1729695309217105997", "1729695117532039245", "1729694777404786765", "1729694767779055693", "1729694762427582541", "1729694748220753997", "1729694733690439757", "1729694722992801869", "1729694652815935565", "1729692293943756877", "1729692231272400973", "1729691683275180109", "1731582484265601101", "1730720901502961741", "1730348481606748237", "1730135628623218765", "1730135628381194317" };
            foreach (var item in listId)
            {
                var param = new TiktokBaseParam<object>()
                {
                    AccessToken = "ROW_8epC-AAAAACRsH14B_A7mqEMozlfuj55bON7wDrc1eUDD1G2-UQtIDjv8PgCplq5WpNkTyNtvDtzVlHIIYjQwnwTvpaW1zIyj0TyYt0R6VvUq_s0vUEkeaqf2ks267SiWSkUFxq0GDa8K3pYHGPLEuUBDIU5fxjq-p_hqE2ZtiQ9EVOjIa5eNg\r\n",
                    ShopCipher = "ROW_Hx0c5gAAAACFURHBQmv72xOUobK_2or6",
                    ID = item,
                };
                listData.Add(await tiktokUtility.GetProductDetails(param));
            }

            //var param = new TiktokBaseParam<object>()
            //{
            //    AccessToken = "ROW_8epC-AAAAACRsH14B_A7mqEMozlfuj55bON7wDrc1eUDD1G2-UQtIDjv8PgCplq5WpNkTyNtvDtzVlHIIYjQwnwTvpaW1zIyj0TyYt0R6VvUq_s0vUEkeaqf2ks267SiWSkUFxq0GDa8K3pYHGPLEuUBDIU5fxjq-p_hqE2ZtiQ9EVOjIa5eNg\r\n",
            //    ShopCipher = "ROW_Hx0c5gAAAACFURHBQmv72xOUobK_2or6",
            //    ID = id,
            //};
            //await tiktokUtility.GetProductDetails(param);

            return "value";
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns
        [HttpPost]
        [Route("printordertiktok")]
        public async Task<object> PrintOrder([FromBody] TiktokBaseParam<object> param)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.Printorder(param);

        }
        [HttpPost]
        [Route("orderdetailtiktok")]
        public async Task<object> OrderDetail([FromBody] TiktokBaseParam<object> param)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();
            param.Route = string.Format(TiktokEndpoints.GetListOrderByIds, param.ID);
            return tiktokUtility.OrderDetail(param);

        }
        [HttpPost]
        [Route("shippackage")]
        public async Task<object> ShipPackage([FromBody] TiktokBaseParam<object> param)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.ShipPackage(param);

        }
        [HttpPost]
        [Route("getreturntiktok")]
        public async Task<object> GetorderReturnTiktok([FromBody] TiktokBaseParam<object> param)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.GetorderReturn(param);

        }

        [HttpPost]
        [Route("getorders")]
        public async Task<object> Getorders([FromBody] TiktokBaseParam<TitkokTimeParam> param)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.Getorders(param);

        }

        [HttpPost]
        [Route("statement_transactions_old")]
        public async Task<object> GetStatementTransactionOlds([FromBody] TiktokBaseParam<object> param)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.GetStatementTransactions(param);

        }
        [HttpPost]
        [Route("statement_transactions")]
        public async Task<object> GetStatementTransactionsNew([FromBody] TiktokBaseParam<object> param)
        {
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.GetStatementTransactionsNew(param);

        }

        //[HttpPost]
        //[Route("/statements")]
        //public async Task<object> FinanceStatements([FromBody] TiktokBaseParam<object> param)
        //{
        //    //ShopeeUtility shopeeUitlity = new ShopeeUtility();
        //    //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
        //    TiktokUtility tiktokUtility = new TiktokUtility();

        //    return tiktokUtility.GetStatementTransactions(param);

        //}

        [Route("get_access_token")]
        public async Task<object> GetAccessToken(string authCode)
        {
            //ShopeeUtility shopeeUitlity = new ShopeeUtility();
            //shopeeUitlity.GetShopeeListOrder(2004299, 2004299, null);
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.GetAccessToken(authCode);

        }

        [HttpPost]
        [Route("get_shop_infor")]
        public async Task<object> GetShopInfo([FromBody] TiktokBaseParam<object> accountParam)
        {
            TiktokUtility tiktokUtility = new TiktokUtility();

            return tiktokUtility.GetShopInfo(accountParam);

        }

        [HttpPost]
        [Route("get_detail_package")]
        public async Task<object> GetDetailPackage([FromBody] TiktokBaseParam<object> param)
        {
            TiktokUtility tiktokUtility = new TiktokUtility();

            PartnerApiResponse response = new PartnerApiResponse();
            param.Method = Method.GET;
            param.Route = string.Format(TiktokEndpoints.GetDetailPackage, param.ID);
            PartnerApiResponse partnerApiResponse = await tiktokUtility.CallTiktokAPI<object, object>(param);
            return partnerApiResponse;
        }
    }
}

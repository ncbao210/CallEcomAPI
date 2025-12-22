using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MISA.HKD.SHOPEE
{
    public class VNPController : ApiController
    {

        public async Task<string> Get(int a)
        {
            var vnpApi = new VNPApi();

            var token = "";

            var res = await vnpApi.GetAccessToken();
            return JsonConvert.SerializeObject(res);
        }
    }
}
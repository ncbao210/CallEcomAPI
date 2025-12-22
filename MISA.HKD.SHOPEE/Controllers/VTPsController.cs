using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MISA.HKD.SHOPEE
{
    public class VTPsController : ApiController
    {
   

        public async Task<string> Get(int aa)
        {
            var token = "";
            var vTPApi = new VTPApi(); 
            var res = await vTPApi.SignInByPartnerAccount();

            return "Hello";
        }
    }
}
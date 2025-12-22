using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MISA.HKD.SHOPEE
{
    public class GHTKController : ApiController
    {

        public async Task<string> Get(int id)
        {
            var utilities = new AhamoveApi();
            string token = "C558B6825299843f03E280eCe4E0b67f3037190a";
            var tokenVTP = "eyJhbGciOiJFUzI1NiJ9.eyJzdWIiOiIwMzk3NTkzODYzIiwiVXNlcklkIjo4MzQxOTI5LCJGcm9tU291cmNlIjo1LCJUb2tlbiI6IlVCMlBRTDJZVTFPWSIsImV4cCI6MTcyNjI5OTE1NiwiUGFydG5lciI6ODM0MTkyOX0.s034HOhZ8sIH7_Bf-4EljMRoXSoNz2V3aaPFSOUNziui6AL2juioQkRuW-1eg_8fS2PV0orgx-d1CHyq0U5GLg";
            var res = await utilities.RegisterAccount();
            return "hello";
        }


    }
}
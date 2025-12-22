using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class GHNBaseParam<T> : BaseShippingPartnerParam
    {
        public string ShopId { get; set; }
        public T Body { get; set; }
    }
}
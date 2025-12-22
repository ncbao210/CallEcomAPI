using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class VTPBaseParam<TBody> : BaseShippingPartnerParam
    {
        public TBody Body { get; set; }
    }
}
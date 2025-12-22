using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class GHTKBaseParam<T> : BaseShippingPartnerParam
    {
        public T Body { get; set; }
    }
}
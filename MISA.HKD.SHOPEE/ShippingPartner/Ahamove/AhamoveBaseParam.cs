using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.HKD.SHOPEE
{
    public class AhamoveBaseParam<T> : BaseShippingPartnerParam
    {
        public object Query { get; set; }
        public T Body
        {
            get;
            set;
        }
    }
}
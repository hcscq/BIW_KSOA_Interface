using System;
using System.Collections.Generic;

namespace BIW_KSOA_Interface.Models
{
    public partial class biw_porders_d
    {
        public string poNo { get; set; }
        public int did { get; set; }
        public string spid { get; set; }

        public string goodsNo { get; set; }

        public Nullable<decimal> goodsPrice { get; set; }
        public Nullable<decimal> goodsQty { get; set; }
        public Nullable<decimal> goodsAmount { get; set; }
        public Nullable<decimal> taxRate { get; set; }
        public Nullable<decimal> withtaxPrice { get; set; }
        public Nullable<decimal> withtaxAmount { get; set; }
        public Nullable<decimal> taxAmount { get; set; }
        public Nullable<int> isGift { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BIW_KSOA_Interface.Models
{
    public partial class biw_priceOnly
    {
        public string goods_id { get; set; }
        public string goods_no { get; set; }
        public Nullable<decimal> retailPrice { get; set; }
        public Nullable<decimal> lastPPrice { get; set; }
        public string mainSupplier { get; set; }
    }
}

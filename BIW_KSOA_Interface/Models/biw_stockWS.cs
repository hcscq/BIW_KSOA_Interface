using System;
using System.Collections.Generic;

namespace BIW_KSOA_Interface.Models
{
    public partial class biw_stockWS
    {
        public string goods_Id { get; set; }
        public decimal month_Sales { get; set; }
        public string goods_No { get; set; }
        public decimal stock_Amount { get; set; }
    }
}

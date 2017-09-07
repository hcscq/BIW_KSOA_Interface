using System;
using System.Collections.Generic;

namespace BIW_KSOA_Interface.Models
{
    public partial class Biw_ReturnPoD
    {
        public string ReturnPoNo { get; set; }
        public string GoodsNo { get; set; }
        public string Lot { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TaxPrice { get; set; }
        public short TaxRate { get; set; }
        public string IsGift { get; set; }
        public string QualityDesc { get; set; }
        public string ExpireDate { get; set; }
        public string GoodsAllocation { get; set; }
        public int InnerId { get; set; }
    }
}

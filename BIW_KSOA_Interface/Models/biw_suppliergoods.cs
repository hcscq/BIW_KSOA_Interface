using System;
using System.Collections.Generic;

namespace BIW_KSOA_Interface.Models
{
    public partial class biw_suppliergoods
    {
        public string jyzt { get; set; }
        public string spx { get; set; }
        public string licenseNo { get; set; }
        public string spid { get; set; }
        public string goodsNo { get; set; }
        public string commonName { get; set; }
        public string proAddr { get; set; }
        public string goodsName { get; set; }
        public string category1No { get; set; }
        public string category2No { get; set; }
        public string category3No { get; set; }
        public string goodsSpec { get; set; }
        public string drugForm { get; set; }
        public string producer { get; set; }
        public string originPlace { get; set; }
        public string packageUnit { get; set; }
        public string supplier_id { get; set; }
        public string supplier_no { get; set; }
        public string supplier_name { get; set; }
        public string rshtqx { get; set; }
        public string jsfs { get; set; }
        public string isjh { get; set; }
        public string spbctj { get; set; }
        public string yp_syff { get; set; }
        public decimal storageQty { get; set; }
        public int storageQtyZc { get; set; }
        public int storageQtyDs { get; set; }
        public int storageQtyMd { get; set; }
        public int monthlySalesYd { get; set; }
        public int stock2useRatio { get; set; }
        public int stock2useRatioFilled { get; set; }
        public decimal goodsPrice { get; set; }
        public Nullable<decimal> taxRate { get; set; }
        public decimal withtaxPrice { get; set; }
        public int lastPrice { get; set; }
        public string settlement { get; set; }
        public string sfzgys { get; set; }
        public string thhbj { get; set; }
    }
}

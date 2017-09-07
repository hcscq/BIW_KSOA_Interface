using System;
using System.Collections.Generic;

namespace BIW_KSOA_Interface.Models
{
    public partial class biw_porders_t
    {
        public string poNo { get; set; }
        public string creatorName { get; set; }
        public string checker { get; set; }
        public string checktime { get; set; }
        public string arrivedate { get; set; }
        public string dptname { get; set; }
        public string createTime { get; set; }
        public string estimatedArrivalTime { get; set; }
        public string supplierNo { get; set; }
        public string warehouseNo { get; set; }
        public string acceptAddr { get; set; }
        public Nullable<decimal> purchaseQty { get; set; }
        public Nullable<decimal> purchaseAmount { get; set; }
        public Nullable<decimal> taxAmount { get; set; }
        public Nullable<decimal> totalAmount { get; set; }
        public Nullable<int> isValueadd { get; set; }
        public Nullable<int> isPrestore { get; set; }
        public string skNo { get; set; }
    }
}

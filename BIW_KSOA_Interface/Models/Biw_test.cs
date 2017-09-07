using System;
using System.Collections.Generic;

namespace BIW_KSOA_Interface.Models
{
    public partial class Biw_test
    {

        public string ReturnPoNo { get; set; }
        public string GoodsNo { get; set; }
        public string Lot { get; set; }
        public int Quantity { get; set; }

        public List<Biw_ReturnPoD> list { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIW_KSOA_Interface.Models
{
    public partial class Biw_ReturnPoM
    {
        public string ReturnPoNo { get; set; }
        public string SupplierNo { get; set; }
        public string CreatorName { get; set; }
        public string CreatorPart { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime InsertDate { get; set; }
        public string Note { get; set; }
        public string Reason { get; set; }
        //[NotMapped]
        //public List<Biw_ReturnPoD> list { get; set; }
    }
}

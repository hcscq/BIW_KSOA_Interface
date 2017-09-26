using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIW_KSOA_Interface.Models
{
    public partial class KSOANoModel
    {
        public string BiwNo { get; set; }
        public string poNo { get { return BiwNo; } set { BiwNo = value; } }
        public string poSkno { get { return ksoaNo; }set { ksoaNo = value; } }
        public string ksoaNo { get; set; }

        public string Msg { get; set; } 

        public bool Success { get; set; }
    }
}

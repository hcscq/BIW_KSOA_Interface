using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIW_KSOA_Interface.Models
{
    public partial class KSOANoModel
    {

        public string ksoaNo { get; set; }

        public string Msg { get; set; }

        public bool Success { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIW_KSOA_Interface.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public partial class KSOANoModel
    {
        [JsonIgnore]
        public string BiwNo { get; set; }
        public string poNo { get { return BiwNo; } set { BiwNo = value; } }
        public string poSkno { get { return ksoaNo; }set { ksoaNo = value; } }
        [JsonIgnore]
        public string ksoaNo { get; set; }
        [JsonIgnore]
        public string Msg { get; set; } 

        public bool Success { get; set; }
    }
}

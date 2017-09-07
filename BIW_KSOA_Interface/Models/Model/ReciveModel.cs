using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIW_KSOA_Interface.Models
{
    [NotMapped]
    public partial class Biw_ReturnPoMWithD : Biw_ReturnPoM
    {

        public List<Biw_ReturnPoD> list { get; set; }
        public Biw_ReturnPoM GetM() {
            return new Biw_ReturnPoM()
            {
                ReturnPoNo = this.ReturnPoNo,
                SupplierNo = this.SupplierNo,
                CreatorName = this.CreatorName,
                CreatorPart = this.CreatorPart,
                CreateDate = this.CreateDate,
                InsertDate = this.InsertDate,
                Note = this.Note
            };
        }
    }
    [NotMapped]
    public class Biw_PriceMaBiwDModel
    {
        public int id
        {
            get;
            set;
        }
        public string priceWhNo
        {
            get;
            set;
        }
        public int did
        {
            get;
            set;
        }
        public string supplierId
        {
            get;
            set;
        }
        public string supplierNo
        {
            get;
            set;
        }
        public string goodsNo
        {
            get;
            set;
        }
        public string goodsName
        {
            get;
            set;
        }
        public float priceJhNow
        {
            get;
            set;
        }
        public float priceLsNow
        {
            get;
            set;
        }
        public string changeReason
        {
            get;
            set;
        }
        public int isMain
        {
            get;
            set;
        }
        public float priceLsOld
        {
            get;
            set;
        }
        public float priceJhOld
        {
            get;
            set;
        }
        public float taxRateIn
        {
            get;
            set;
        }
    }
    [NotMapped]
    public class Biw_PriceMaBiwMModel
    {
        public int id
        {
            get;
            set;
        }
        public List<Biw_PriceMaBiwDModel> DList
        {
            get;
            set;
        }
        public string priceWhNo
        {
            get;
            set;
        }
        public int detailCount
        {
            get;
            set;
        }
        public int creator
        {
            get;
            set;
        }
        public string updateUser
        {
            get;
            set;
        }
    }
}

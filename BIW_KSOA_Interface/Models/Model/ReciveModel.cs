using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIW_KSOA_Interface.Models
{
    [NotMapped]
    public partial class Biw_ReturnPoMWithD : Biw_ReturnPoM
    {

        public List<Biw_ReturnPoD> list { get; set; }
        public Biw_ReturnPoM GetM()
        {
            return new Biw_ReturnPoM()
            {
                ReturnPoNo = this.ReturnPoNo,
                SupplierNo = this.SupplierNo,
                CreatorName = this.CreatorName,
                CreatorPart = this.CreatorPart,
                CreateDate = this.CreateDate,
                InsertDate = this.InsertDate,
                Note = this.Note,
                Reason=this.Reason
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
    [NotMapped]
    public class Biw_PoModel : biw_porders_t
    {
        public List<biw_porders_d> dList { get; set; }
        public List<biw_porders_d> detailList { get { return dList; } set { dList = value; } }
        public biw_porders_t GetM()
        {
            return new biw_porders_t()
            {
                poNo = this.poNo,
                creatorName = this.creatorName,
                checker = this.checker,
                checktime = this.checktime,
                arrivedate = this.arrivedate,
                dptname = this.dptname,
                createTime = this.createTime,
                estimatedArrivalTime = this.estimatedArrivalTime,
                supplierNo = this.supplierNo,
                warehouseNo = this.warehouseNo,
                acceptAddr = this.acceptAddr,
                purchaseQty = this.purchaseQty,
                purchaseAmount = this.purchaseAmount,
                taxAmount = this.taxAmount,
                totalAmount = this.totalAmount,
                isValueadd = this.isValueadd,
                isPrestore = this.isPrestore
            };
        }
    }
    [NotMapped]
    public class BiwQryModel
    {
        public string supplier_no
        {
            get { return supplierNo; }
            set { supplierNo = value; }
        }
        public string supplier_name
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
        public string goods_no
        {
            get { return goodsNo; }
            set { goodsNo = value; }
        }
        public string goods_name
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        public string supplierName
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
        public int page_size { get { return pageSize; } set { pageSize = value; } }
        public int page_no { get { return pageNo; } set { pageNo = value; } }
        public int pageSize { get; set; }
        public int pageNo { get; set; }
        public int qry_type { get { return qryType; } set { qryType = value; } }
        public int qryType { get; set; }
    }
    [NotMapped]
    public class BiwQrySupplierGoodsModel
    {
        public string supplier_no
        {
            get { return supplierNo; }
            set { supplierNo = value; }
        }
        public string supplierNo { get; set; }
        public List<string> goods_no { get { return goodsNo; } set { goodsNo = value; } }
        public List<string> goodsNo { get; set; }
    }
    [NotMapped]
    public class BiwQryGoodsWitnMSModel
    {
        public List<string> goodsId { get; set; }
    }
    [NotMapped]
    public class BiwQryGoodsCategoryModel:biw_category
    {        
    }
}

﻿using BIW_KSOA_Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIW_KSOA_Interface.Common
{
    public static class PostMessage
    {

        public class saveReturnPo : Biw_BasePostMsgModel
        {
            public Biw_ReturnPoMWithD Body { get; set; }
        }
        //public class priceMaSave : Biw_BasePostMsgModel
        //{
        //    public Biw_PriceMaBiwMModel Body { get; set; }
        //}
        public class priceMaSaveBatch : Biw_BasePostMsgModel
        {
            public List<Biw_PriceMaBiwMModel>  Body { get; set; }
        }
        public class poSave:Biw_BasePostMsgModel
        {
            public Biw_PoModel Body{ get; set; }

        }
        public class BiwQryData : Biw_BasePostMsgModel
        {
            public BiwQryModel Body { get; set; }
        }
        public class BiwQryDataBatch : Biw_BasePostMsgModel
        {
            public List<BiwQryModel> Body { get; set; }
        }
        public class BiwQrySupplierGoods : Biw_BasePostMsgModel
        {
            public BiwQrySupplierGoodsModel Body { get; set; }
        }
        public class BiwQryGoodsWS : Biw_BasePostMsgModel
        {
            public BiwQryGoodsWitnMSModel Body { get; set; }
        }
        public class BiwQryGoodsCategory : Biw_BasePostMsgModel
        {
            public BiwQryGoodsCategoryModel Body { get; set; }
        }
    }
}
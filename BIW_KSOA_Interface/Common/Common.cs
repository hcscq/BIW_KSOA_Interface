using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIW_KSOA_Interface.Common
{
    public  class Common
    {
        public static InsiderPrice[] insiderFavourInfo = new InsiderPrice[]
    {
            new InsiderPrice
            {
                favourType = FavourableType.PERCENT,
                favourableVal = 0.98,
                thresholdValue = 3000.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.PERCENT,
                favourableVal = 0.96,
                thresholdValue = 2000.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.PERCENT,
                favourableVal = 0.95,
                thresholdValue = 1000.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 30.0,
                thresholdValue = 600.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 25.0,
                thresholdValue = 500.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 20.0,
                thresholdValue = 400.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 17.0,
                thresholdValue = 350.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 15.0,
                thresholdValue = 300.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 12.5,
                thresholdValue = 250.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 11.0,
                thresholdValue = 220.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 9.0,
                thresholdValue = 180.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 7.5,
                thresholdValue = 150.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 6.0,
                thresholdValue = 120.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 5.0,
                thresholdValue = 100.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 4.0,
                thresholdValue = 80.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 3.0,
                thresholdValue = 60.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 2.0,
                thresholdValue = 50.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 1.5,
                thresholdValue = 40.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 1.0,
                thresholdValue = 30.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 0.8,
                thresholdValue = 20.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 0.5,
                thresholdValue = 15.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 0.4,
                thresholdValue = 10.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 0.3,
                thresholdValue = 5.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.DESC,
                favourableVal = 0.2,
                thresholdValue = 1.0
            },
            new InsiderPrice
            {
                favourType = FavourableType.PERCENT,
                favourableVal = 1.0,
                thresholdValue = 0.1
            },
            new InsiderPrice
            {
                favourType = FavourableType.PERCENT,
                favourableVal = 1.0,
                thresholdValue = 0.0
            }
    };
        public static bool ValidBody(ref Biw_BasePostMsgModel msgModel, ref JsonResult jr)
        {
            if (msgModel == null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return false;
            }
            return true;
        }
    }
    public static class MessageId
    {
        public const string SaveReturnPo = "SaveReturnPo";
        public const string SavePo = "SavePo";
        public const string SavePriceMa = "SavePriceMa";
    }
    public partial class Biw_BasePostMsgModel
    {

        public string Action { get; set; }
        public string Key { get; set; }
        public DateTime Time { get; set; }
        //public object Body { get; set; }
    }
    public partial class Biw_ResultMsgModel
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Body { get; set; }

    }
    public enum FavourableType
    {
        DESC,
        PERCENT
    }
    public struct InsiderPrice
    {
        public FavourableType favourType;
        public double thresholdValue;
        public double favourableVal;
    }
    
}
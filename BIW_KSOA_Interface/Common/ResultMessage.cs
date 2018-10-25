using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace BIW_KSOA_Interface.Common
{
    public static class ResultMessage
    {

        //public static class ResultMessage
        //{
        //    public const string HaveNoData = "未接收到任何数据.";
        //    public const string NoSuchMessageId = "接口不存在.";
        //    public const string DataError = "传入数据有问题.";
        //    public const string ProcError = "调用存储过程出错.";

        //}
        public static string GetEntityValidationErrorStr(DbEntityValidationException e1)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var it1 in e1.EntityValidationErrors)
            {
                foreach (var it2 in it1.ValidationErrors)
                {
                    Logger.WriteLog(it2.ErrorMessage);
                    sb.Append(it2.ErrorMessage);
                }

            }
            return sb.ToString();
        }
        //public class Batch
        public  class HaveNoData : Biw_ResultMsgModel
        {
            public HaveNoData()
            {
                Message = "未接收到任何数据.";
                Success = false;
            }
        }
        public class NoSuchMessageId : Biw_ResultMsgModel
        {
            public NoSuchMessageId()
            {
                Message = "接口不存在.";
                Success = false;
            }
        }
        public class DataError : Biw_ResultMsgModel
        {
            public DataError()
            {
                Message = "传入数据有问题.";
                Success = false;
            }
        }
        public class ProcError : Biw_ResultMsgModel
        {
            public ProcError()
            {
                Message = "调用存储过程出错.";
                Success = false;
            }
        }
        public class Successed : Biw_ResultMsgModel
        {
            public Successed()
            {
                Message = "成功.";
                Success = true;
            }
        }
        public class ParamError : Biw_ResultMsgModel
        {
            public ParamError()
            {
                Message = "查询参数错误.";
                Success = false;
            }
        }
        public class SuccessedWithCount : Successed
        {
            public int count { get; set; }
        }

        public class CompanyCodeError : Biw_ResultMsgModel
        {
            public CompanyCodeError()
            {
                Message = "公司编号有误.";
                Success = false;
            }
        }
    }
}
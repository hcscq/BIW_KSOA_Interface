using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIW_KSOA_Interface.Models;
using BIW_KSOA_Interface.Common;
using System.Web.Script.Serialization;
using System.Data.Entity.Validation;
using System.Text;
using System.Data.SqlClient;

namespace BIW_KSOA_Interface.Controllers
{
    public class BIWController : Controller
    {
        //
        // GET: /BIW/
        private JavaScriptSerializer jsr = new JavaScriptSerializer();
        public ActionResult Index()
        {
            return View();
        }
        #region Header + Body(String) Mode ---Common Accept
        //[HttpPost]
        //public JsonResult Biw(Biw_PostMsgModel msgModel)
        //{
        //    JsonResult jr = new JsonResult();
        //    jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

        //    if (msgModel == null||msgModel.Body==null)
        //    {
        //        jr.Data = new ResultMessage.HaveNoData();
        //        return jr;
        //    }


        //    switch (msgModel.Action)
        //    {
        //        case MessageId.SaveReturnPo:
        //            break;
        //            return saveReturnPo(msgModel.Body);

        //        default:break;
        //    }

        //    return jr;
        //}
        #endregion
        /// <summary>
        /// 退供单 提交
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult saveReturnPo(PostMessage.saveReturnPo msgModel) 
         {

            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            KSOANoModel result=null;
            if (msgModel == null||msgModel.Body==null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            #region Header + Body(String) Mode
            //Biw_ReturnPoMWithD model =null;

            //try
            //{
            //    model = jsr.Deserialize<Biw_ReturnPoMWithD>(msgModel.Body);
            //}
            //catch (Exception e1)
            //{
            //    jr.Data = new ResultMessage.DataError() {Message=e1.Message };
            //    Logger.WriteLog(e1.Message);
            //    Logger.WriteLog("Body Data:"+msgModel.Body);
            //    return jr;
            //}
            //*********需要测试 修改 原Model 之后直接存入数据库 的方法
            #endregion
            using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
            {
                try
                {
                    msgModel.Body.InsertDate = DateTime.Now;
                    dbContext.Biw_ReturnPoM.Add(msgModel.Body.GetM());
                    dbContext.Biw_ReturnPoD.AddRange(msgModel.Body.list);
                    dbContext.SaveChanges();
                    result = dbContext.ProcedureQuery<KSOANoModel>("biw_Save_ReturnPo @returnPoNo='" + msgModel.Body.ReturnPoNo + "'").First();

                }
                catch (DbEntityValidationException e1)
                {
                    jr.Data = new ResultMessage.ProcError() { Message = ResultMessage.GetEntityValidationErrorStr(e1) };
                    Logger.WriteLog("Body Data:" +jsr.Serialize(msgModel.Body));
                    return jr;
                }
                catch (Exception e1)
                {
                    while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                        e1 = e1.InnerException;
                    jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                    Logger.WriteLog(e1.Message);
                    Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                    return jr;
                }
            }
            jr.Data = new ResultMessage.Successed() {Body=jsr.Serialize(result) };
            return jr;
        }
        /// <summary>
        /// 维价单 批量提交
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost] 
        public JsonResult priceMaSaveBatch(PostMessage.priceMaSaveBatch msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null||msgModel.Body==null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            List<priceMa> saveList = new List<priceMa>();
            List<Biw_PriceMaBiwMModel> postList=msgModel.Body;
            string gzid;
            Random random=new Random();
            List<KSOANoModel> resultList = new List<KSOANoModel>();
            for (int i = 0; i < postList.Count; i++)
            {
                gzid = DateTime.Now.Ticks.ToString().Substring(0, 9).ToString() + (random.Next() % 99).ToString();
                if (postList[i].DList.Count > 0)
                {
                    for (int j = 0; j < postList[i].DList.Count<Biw_PriceMaBiwDModel>(); j++)
                    {
                        priceMa priceMaKsoaModel = new priceMa();
                        priceMaKsoaModel.gzid = gzid;
                        priceMaKsoaModel.spbh = postList[i].DList[j].goodsNo;
                        priceMaKsoaModel.spmch = postList[i].DList[j].goodsName;
                        priceMaKsoaModel.hshjj = (decimal)postList[i].DList[j].priceJhNow;
                        priceMaKsoaModel.is_zgys = ((postList[i].DList[j].isMain == 0) ? "否" : "是");
                        priceMaKsoaModel.zhjj = (decimal)postList[i].DList[j].priceJhOld;
                        priceMaKsoaModel.dj = (decimal)postList[i].DList[j].priceLsNow;
                        priceMaKsoaModel.shlv = (decimal)postList[i].DList[j].taxRateIn;
                        priceMaKsoaModel.orderId = postList[i].priceWhNo;
                        priceMaKsoaModel.dj_sn = j;
                        priceMaKsoaModel.dj_sort = j;
                        priceMaKsoaModel.danwbh = postList[i].DList[j].supplierNo;
                        priceMaKsoaModel.insertDate = DateTime.Now;
                        #region 计算会员价
                        foreach (InsiderPrice current in Common.Common.insiderFavourInfo.OrderBy(it => it.thresholdValue))
                        {
                            if (current.thresholdValue == 0.0)
                            {
                                if (current.favourType == FavourableType.DESC)
                                {
                                    priceMaKsoaModel.hyj = (double)priceMaKsoaModel.dj - current.favourableVal;
                                }
                                else
                                {
                                    if (current.favourType == FavourableType.PERCENT)
                                    {
                                        priceMaKsoaModel.hyj = (double)priceMaKsoaModel.dj * current.favourableVal;
                                    }
                                }
                            }
                            else
                            {
                                if ((double)priceMaKsoaModel.dj / current.thresholdValue <= 1.0)
                                {
                                    break;
                                }
                                if (current.favourType == FavourableType.DESC)
                                {
                                    priceMaKsoaModel.hyj = (double)priceMaKsoaModel.dj - current.favourableVal;
                                }
                                else
                                {
                                    if (current.favourType == FavourableType.PERCENT)
                                    {
                                        priceMaKsoaModel.hyj = (double)priceMaKsoaModel.dj * current.favourableVal;
                                    }
                                }
                            }
                        }
                        #endregion
                        saveList.Add(priceMaKsoaModel);

                    }
                    try
                    {
                        using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                        {
                            dbContext.priceMas.AddRange(saveList);
                            dbContext.SaveChanges();
                            dbContext.ProcedureQuery("zz_gsspwh_biw", new SqlParameter("@gzid",gzid)
                                                                    ,new SqlParameter("@djlxbs", "GSS")
                                                                    ,new SqlParameter("@djbh",postList[i].priceWhNo)
                                                                    ,new SqlParameter("@rq", DateTime.Now.ToString("yyyy-MM-dd"))
                                                                    ,new SqlParameter("@username",postList[i].updateUser));
                        }
                    }
                    catch (DbEntityValidationException e1)
                    {
                        Logger.WriteLog("Body Data:" + jsr.Serialize(saveList));
                        resultList.Add(new KSOANoModel() {BiwNo=postList[i].priceWhNo,Msg= ResultMessage.GetEntityValidationErrorStr(e1),Success=false });
                    }
                    catch (Exception e1)
                    {
                        while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                            e1 = e1.InnerException;
                        Logger.WriteLog(e1.Message);
                        Logger.WriteLog("Body Data:" + jsr.Serialize(saveList));
                        resultList.Add(new KSOANoModel() { BiwNo = postList[i].priceWhNo, Msg = e1.Message, Success = false });
                    }
                    saveList.Clear();
                }
            }

            if (resultList.Count > 0)
                jr.Data = new ResultMessage.ProcError() { Body = jsr.Serialize(resultList) };
            else jr.Data = new ResultMessage.Successed();

            return jr;
        }
        /// <summary>
        /// 采购单 提交
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult poSave(PostMessage.poSave msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            KSOANoModel result = null;
            if (msgModel == null||msgModel.Body==null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    dbContext.biw_porders_t.Add(msgModel.Body.GetM());
                    dbContext.biw_porders_d.AddRange(msgModel.Body.dList);
                    dbContext.SaveChanges();

                    result=dbContext.ProcedureQuery<KSOANoModel>("sbp_biw_porders @poNo='" + msgModel.Body.poNo + "'").First();

                }
            }
            catch (DbEntityValidationException e1)
            {
                jr.Data = new ResultMessage.ProcError() { Message = ResultMessage.GetEntityValidationErrorStr(e1) };
                Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                return jr;
            }
            catch (Exception e1)
            {
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                return jr;
            }
            jr.Data = new ResultMessage.Successed() { Body = jsr.Serialize(result) };
            return jr;
        }
        /// <summary>
        /// 查询供应商信息
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult qry_supplierOnly(PostMessage.BiwQryData msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            if (string.IsNullOrWhiteSpace(msgModel.Body.supplierName) && string.IsNullOrWhiteSpace(msgModel.Body.supplierNo))
            {
                jr.Data = new ResultMessage.ParamError();
                Logger.WriteLog("Query param is empty.");
                return jr;
            }
            //dwbh as supplier_id,danwbh as supplier_no,dwmch as supplier_name,rshtqx,isjh,jsfs 
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = from q in dbContext.mchks
                                select new
                                {
                                    supplier_id = q.dwbh,
                                    supplier_no = q.danwbh,
                                    supplier_name = q.dwmch,
                                    q.rshtqx,
                                    q.isjh,
                                    q.jsfs
                                };
                    if (!string.IsNullOrWhiteSpace(msgModel.Body.supplierName))
                        query = query.Where(it => it.supplier_name.Contains(msgModel.Body.supplierName.Trim()));
                    if (!string.IsNullOrWhiteSpace(msgModel.Body.supplierNo))
                        query = query.Where(it => it.supplier_no.Equals(msgModel.Body.supplierNo.Trim()));

                    jr.Data = new ResultMessage.Successed() { Body = jsr.Serialize(query) };

                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("see the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                return jr;
            }

            return jr;
        }
        /// <summary>
        /// 查询移动月销量(记得修改视图名称)
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult QryMonthSales(PostMessage.BiwQryDataBatch msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || msgModel.Body.Count() <= 0)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var goodsNoArr = msgModel.Body.Select(it => it.goodsNo.Trim()).ToArray();
                    var query = from q in dbContext.biw_MSOnly
                                where (goodsNoArr).Contains(q.spbh)
                                select q;
                    jr.Data = new ResultMessage.Successed() { Body = jsr.Serialize(query) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                return jr;
            }
            return jr;
        }
        /// <summary>
        /// 商品信息 批量查询
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult multi_qry_goods(PostMessage.BiwQryDataBatch msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || msgModel.Body.Count() <= 0)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            try
            {
                string[] goodsNameArr;
                string[] goodsNoArr = msgModel.Body
                    .Where(it => !string.IsNullOrWhiteSpace(it.goodsNo))
                    .Select(it => it.goodsNo.Trim()).Distinct().ToArray();

                List<string> goodsNameList = msgModel.Body
                    .Where(it => string.IsNullOrWhiteSpace(it.goodsNo) && !string.IsNullOrWhiteSpace(it.goodsName))
                    .Select(it => (it.goodsName.Trim())).Distinct().ToList();

                for (int i=0;i< goodsNameList.Count;i++)
                    goodsNameList.RemoveAll(it=>it.Contains(goodsNameList[i])&&it!= goodsNameList[i]);

                goodsNameArr = goodsNameList.ToArray();

                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = (from q in dbContext.spkfks
                                 //from p in goodsNoArr
                                 where goodsNoArr.Contains(q.spbh)//q.spbh== p//
                                 select new
                                 {
                                     q.spid,
                                     goodsNo = q.spbh,
                                     goodsName = q.spmch,
                                     category1No = q.yjfl.Trim(),
                                     category2No = q.ejfl.Trim(),
                                     category3No = q.sjfl.Trim(),
                                     originPlace = q.shpchd.Trim(),
                                     goodsSpec = q.shpgg,
                                     producer = q.shengccj,
                                     packageunit = q.dw,
                                     goodsPrice = q.jj,
                                     taxRate = q.shlv,
                                     withtaxPrice = q.hshjj,
                                     commonName = q.tongym
                                 })
                                 .Union((from q in dbContext.spkfks
                                         from p in goodsNameArr
                                         where q.spmch.Contains(p)
                                         select new
                                         {
                                             q.spid,
                                             goodsNo = q.spbh,
                                             goodsName = q.spmch,
                                             category1No = q.yjfl.Trim(),
                                             category2No = q.ejfl.Trim(),
                                             category3No = q.sjfl.Trim(),
                                             originPlace = q.shpchd.Trim(),
                                             goodsSpec = q.shpgg,
                                             producer = q.shengccj,
                                             packageunit = q.dw,
                                             goodsPrice = q.jj,
                                             taxRate = q.shlv,
                                             withtaxPrice = q.hshjj,
                                             commonName = q.tongym
                                         }));
                    jr.Data = new ResultMessage.Successed() { Body = jsr.Serialize(query) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                return jr;
            }
            return jr;
        }
        /// <summary>
        /// 最后进价 批量查询 支持混合查询(记得修改视图名称)
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getPurchasePriceOnly(PostMessage.BiwQryDataBatch msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || msgModel.Body.Count() <= 0)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            try
            {
                List<string> goodsOnlyList = new List<string>();
                List<BiwQryModel> goodsWithSupplierList = new List<BiwQryModel>();
                foreach (var item in msgModel.Body)
                {
                    if (!string.IsNullOrWhiteSpace(item.goodsNo))
                        if (!string.IsNullOrWhiteSpace(item.supplierNo))
                            goodsWithSupplierList.Add(item);
                        else goodsOnlyList.Add(item.goodsNo);
                }
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = from q in dbContext.biw_priceOnly
                                from p in goodsOnlyList
                                where q.goods_no == p
                                select new
                                {
                                    q.goods_id,
                                    q.goods_no,
                                    q.lastPPrice,
                                    q.retailPrice,
                                    mainSupplier = q.mainSupplier.Trim(),
                                    SHLV = string.Empty,
                                    supplierNo = string.Empty
                                };
                    if (goodsWithSupplierList.Count > 0)
                    {
                        List<string> goodsNoList = goodsWithSupplierList.Select(it =>it.goodsNo).ToList();
                        List<string> supplierNoList = goodsWithSupplierList.Select(it => it.supplierNo).ToList();
                        var list = query.Union
                            (
                            (from q in dbContext.biw_priceOnly 
                             from r in dbContext.gsspdybs
                             where (q.goods_id == r.spid) &&goodsNoList.Contains(q.goods_no)&&supplierNoList.Contains(r.dwbh)
                             select new
                             {
                                 q.goods_id,
                                 q.goods_no,
                                 q.lastPPrice,
                                 q.retailPrice,
                                 mainSupplier = q.mainSupplier.Trim(),
                                 SHLV = r.shlv.ToString(),
                                 supplierNo = r.dwbh
                             })
                            ).AsEnumerable();
                        list= from q in list
                                join p in goodsWithSupplierList on new { goodsNo = q.goods_no, q.supplierNo } equals new { p.goodsNo, p.supplierNo }
                                select q;
                    }
                    jr.Data = new ResultMessage.Successed() { Body = jsr.Serialize(query) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                return jr;
            }
            return jr;
        }
        [HttpPost]
        public JsonResult batch_qry_goods(PostMessage.BiwQryDataBatch msgModel) { return multi_qry_goods(msgModel); }
        [HttpPost]
        public JsonResult getSupplierGoodsInfo(PostMessage.BiwQryDataBatch msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || msgModel.Body.Count() <= 0)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }

            return jr;
        }
    }
}

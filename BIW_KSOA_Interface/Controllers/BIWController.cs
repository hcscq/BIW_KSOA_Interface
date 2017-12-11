using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIW_KSOA_Interface.Models;
using BIW_KSOA_Interface.Common;
using System.Data.Entity.Validation;
using System.Text;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BIW_KSOA_Interface.Controllers
{
    public class BIWController : Controller
    {
        //
        // GET: /BIW/
        //private JavaScriptSerializer jsr = new JavaScriptSerializer();
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
            KSOANoModel result = null;
            if (msgModel == null || msgModel.Body == null)
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
                    if (!result.Success)
                    {
                        Logger.WriteLog("Process Error:" + result.Msg);
                        Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                        jr.Data = new ResultMessage.ProcError() { Body = result.Msg };
                        return jr;
                    }

                }
                catch (DbEntityValidationException e1)
                {
                    jr.Data = new ResultMessage.ProcError() { Message = ResultMessage.GetEntityValidationErrorStr(e1) };
                    Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                    return jr;
                }
                catch (Exception e1)
                {
                    while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                        e1 = e1.InnerException;
                    jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                    Logger.WriteLog(e1.Message);
                    Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                    return jr;
                }
            }
            jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(result) };
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
            if (msgModel == null || msgModel.Body == null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            List<priceMa> saveList = new List<priceMa>();
            List<Biw_PriceMaBiwMModel> postList = msgModel.Body;
            string gzid;
            Random random = new Random();
            List<KSOANoModel> resultList = new List<KSOANoModel>();
            int returnValue = -1;
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
                        priceMaKsoaModel.hshjj = postList[i].DList[j].priceJhNow;
                        priceMaKsoaModel.is_zgys = ((postList[i].DList[j].isMain == 0) ? "否" : "是");
                        priceMaKsoaModel.zhjj = postList[i].DList[j].priceJhOld;
                        priceMaKsoaModel.dj = postList[i].DList[j].priceLsNow;
                        priceMaKsoaModel.shlv = postList[i].DList[j].taxRateIn;
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
                            returnValue = dbContext.ProcedureQuery("zz_gsspwh_biw", new SqlParameter("@gzid", gzid)
                                                                    , new SqlParameter("@djlxbs", "GSS")
                                                                    , new SqlParameter("@djbh", postList[i].priceWhNo)
                                                                    , new SqlParameter("@rq", DateTime.Now.ToString("yyyy-MM-dd"))
                                                                    , new SqlParameter("@username", postList[i].updateUser));
                        }
                    }
                    catch (DbEntityValidationException e1)
                    {
                        Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(saveList));
                        resultList.Add(new KSOANoModel() { BiwNo = postList[i].priceWhNo, Msg = ResultMessage.GetEntityValidationErrorStr(e1), Success = false });
                    }
                    catch (Exception e1)
                    {
                        while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                            e1 = e1.InnerException;
                        Logger.WriteLog(e1.Message);
                        Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(saveList));
                        resultList.Add(new KSOANoModel() { BiwNo = postList[i].priceWhNo, Msg = e1.Message, Success = false });
                    }
                    saveList.Clear();
                }
            }

            if (resultList.Count > 0)
                jr.Data = new ResultMessage.ProcError() { Body = JsonConvert.SerializeObject(resultList) };
            else jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(returnValue) };

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
            string ip = Request.UserHostAddress;
            if (msgModel == null || msgModel.Body == null||msgModel.Body.dList==null||msgModel.Body.dList.Count<=0)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty or dList is empty.");
                return jr;
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = (from q in dbContext.biw_porders_t
                                 where q.poNo.Trim() == msgModel.Body.poNo.Trim()
                                 select new
                                 {
                                     q.poNo,
                                     poSkno = q.skNo,
                                     Success = true
                                 }).AsNoTracking();
                    if (query.Count() > 0)
                    {
                        var firstItem = query.First();
                        if (!string.IsNullOrWhiteSpace(firstItem.poSkno))
                        {
                            jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(firstItem) };
                            return jr;
                        }
                        result = dbContext.ProcedureQuery<KSOANoModel>("sbp_biw_porders @poNo='" + msgModel.Body.poNo + "'").First();
                    }
                    else
                    {
                        dbContext.biw_porders_t.Add(msgModel.Body.GetM());
                        
                        for (int i = 0; i < msgModel.Body.dList.Count; i++)
                            msgModel.Body.dList[i].poNo = msgModel.Body.poNo;
                        dbContext.biw_porders_d.AddRange(msgModel.Body.dList);
                        dbContext.SaveChanges();


                        result = dbContext.ProcedureQuery<KSOANoModel>("sbp_biw_porders @poNo='" + msgModel.Body.poNo + "'").First();
                    }
                }
            }
            catch (DbEntityValidationException e1)
            {
                jr.Data = new ResultMessage.ProcError() { Message = ResultMessage.GetEntityValidationErrorStr(e1) };
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }
            catch (Exception e1)
            {
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }
            jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(result) };
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
                    var query = (from q in dbContext.mchks
                                 select new
                                 {
                                     supplier_id = q.dwbh,
                                     supplier_no = q.danwbh,
                                     supplier_name = q.dwmch,
                                     q.rshtqx,
                                     q.isjh,
                                     q.jsfs
                                 }).AsNoTracking();
                    if (!string.IsNullOrWhiteSpace(msgModel.Body.supplierName))
                        query = query.Where(it => it.supplier_name.Contains(msgModel.Body.supplierName.Trim()));
                    if (!string.IsNullOrWhiteSpace(msgModel.Body.supplierNo))
                        query = query.Where(it => it.supplier_no.Equals(msgModel.Body.supplierNo.Trim()));

                    jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(query) };

                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("see the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
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
                    var query = (from q in dbContext.biw_MSOnly
                                 where (goodsNoArr).Contains(q.spbh)
                                 select q).AsNoTracking();
                    jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(query) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }
            return jr;
        }
        /// <summary>
        /// 商品信息 批量查询
        /// {"action":"multi_qry_goods","body":[{goodsNo:"204010094"},{goodsNo:"204010105"},{goodsNo:"204010145"},{goods_name:"test3"},{goodsNo:"204020036"}]}
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

                for (int i = 0; i < goodsNameList.Count; i++)
                    goodsNameList.RemoveAll(it => it.Contains(goodsNameList[i]) && it != goodsNameList[i]);

                goodsNameArr = goodsNameList.ToArray();

                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = ((from q in dbContext.spkfks
                                      //from p in goodsNoArr
                                  where goodsNoArr.Contains(q.spbh)&& q.beactive.Trim().Equals("是")//q.spbh== p//
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
                                         }))).AsNoTracking();
                    jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(query) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }
            return jr;
        }
        /// <summary>
        /// 最后进价 批量查询 支持混合查询(记得修改视图名称)
        /// {"Action":"SK10012","Body":[{"supplier_no":"LSS10050189","goods_no":"401990096"}],"Key":"GZ0001","Time":"2017-09-21 18:28:00"}
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
                    var query = (from q in dbContext.biw_priceOnly
                                 from p in goodsOnlyList
                                 where q.goods_no == p
                                 select new
                                 {
                                     q.goods_id,
                                     q.goods_no,
                                     q.lastPPrice,
                                     q.retailPrice,
                                     mainSupplier = q.mainSupplier.Trim(),
                                     taxRateIn = string.Empty,
                                     supplierNo = string.Empty
                                 }).AsNoTracking();
                    if (goodsWithSupplierList.Count > 0)
                    {
                        List<string> goodsNoList = goodsWithSupplierList.Select(it => it.goodsNo).ToList();
                        List<string> supplierNoList = goodsWithSupplierList.Select(it => it.supplierNo).ToList();
                        var list = query.Union
                            (
                            (from q in dbContext.biw_priceOnly
                             join p in
                             (
                             from r in dbContext.gsspdybs
                             join m in dbContext.mchks on r.dwbh equals m.dwbh
                             where supplierNoList.Contains(m.danwbh)
                             select new { r.spid, m.danwbh,  r.shlv }
                             )
                             on q.goods_id equals p.spid
                             into temp
                             from t in temp.DefaultIfEmpty()
                             where goodsNoList.Contains(q.goods_no)
                             select new
                             {
                                 q.goods_id,
                                 q.goods_no,
                                 q.lastPPrice,
                                 q.retailPrice,
                                 mainSupplier = q.mainSupplier.Trim(),
                                 taxRateIn = t.shlv.ToString(),
                                 supplierNo = t.danwbh
                             })
                            ).AsNoTracking().AsEnumerable();
                        //list = (from q in list
                        //       join p in goodsWithSupplierList on new { goodsNo = q.goods_no.Trim(), supplierNo=q.supplierNo.Trim() } equals new { goodsNo=p.goodsNo.Trim(), supplierNo=p.supplierNo.Trim() }
                        //       select q);
                        jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(list) };
                    }
                    else
                        jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(query) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }
            return jr;
        }
        [HttpPost]
        public JsonResult batch_qry_goods(PostMessage.BiwQryDataBatch msgModel) { return multi_qry_goods(msgModel); }
        /// <summary>
        /// 查询供应商商品信息  可附带指定商品
        /// {"action":"getSupplierGoodsInfo","body":{"supplierNo":"051","goodsNo":["206020005","204010026","204020001","204010094"]}}
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getSupplierGoodsInfo(PostMessage.BiwQrySupplierGoods msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || string.IsNullOrWhiteSpace(msgModel.Body.supplierNo))
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty or SupplierNo is Null Or whiteSpace.");
                return jr;
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = (from q in dbContext.biw_suppliergoods
                                 where q.supplier_no != null && msgModel.Body.supplierNo.Equals(q.supplier_no)
                                 select q).AsNoTracking();
                    int count = query.Count();
                    if (msgModel.Body.goodsNo != null && msgModel.Body.goodsNo.Count() > 0)
                    {
                        query = query.Where(it => msgModel.Body.goodsNo.Contains(it.goodsNo));
                    }
                    jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(new { rows = query, total = count }) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }

            return jr;
        }
        /// <summary>
        /// 商品库存查询 +移动月销量 +待入数量
        /// </summary>
        /// <param name="msgModel">商品ID数据或商品编号数组</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getGoodsInfo(PostMessage.BiwQryGoodsWS msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            if (((msgModel.Body.goodsId == null&&msgModel.Body.goodsNo==null) || ((msgModel.Body.goodsId != null && msgModel.Body.goodsNo == null)&&msgModel.Body.goodsId.Count <= 0)
                || ((msgModel.Body.goodsNo != null && msgModel.Body.goodsId == null) && msgModel.Body.goodsNo.Count <= 0)))
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("GoodsNo or GoodsID array needed.");
                return jr;
            }
            List<string> condition = null;
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    dbContext.Database.CommandTimeout = 120;

                    if (((msgModel.Body.goodsId != null) && msgModel.Body.goodsId.Count > 0))
                        condition = msgModel.Body.goodsId;
                    else if (((msgModel.Body.goodsNo != null) && msgModel.Body.goodsNo.Count > 0))
                        condition = (from q in dbContext.spkfks
                                     where msgModel.Body.goodsNo.Contains(q.spbh)
                                     select new { q.spid }).AsNoTracking().Select(it => it.spid).ToList();
                    var query = (from q in dbContext.biw_data
                                 join p in condition on q.spid.Trim() equals p.Trim()
                                 select q).AsNoTracking();
                    var query1 = (from q in query
                                  join p in dbContext.spkfks on q.spid.Trim() equals p.spid.Trim()
                                  select new
                                  {
                                      spid = q.spid,
                                      monthsale = q.monthsale,
                                      zhjj = q.zhjj,
                                      stock = q.stock,
                                      drshl = q.drshl,
                                      goodsNo = p.spbh.Trim()
                                  }).AsNoTracking();
                    jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(query1) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }
            return jr;
        }
        /// <summary>
        /// 查询供应商商品信息 分页模式
        /// {"Action":"qry_goods","Key":"TG0001","Time":"2017-08-22","Body":{"supplierNo":"051","goodsName":"云","pageNo":0,"pageSize":10}}
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult qry_goods(PostMessage.BiwQryData msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || string.IsNullOrWhiteSpace(msgModel.Body.supplierNo) || msgModel.Body.pageSize <= 0 || msgModel.Body.pageNo <= 0)
            {
                jr.Data = new ResultMessage.ParamError();
                Logger.WriteLog("Model is empty or SupplierNo is Null Or whiteSpace.Page size and number must greater than 0.");
                return jr;
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = (from q in dbContext.biw_suppliergoods
                                 where q.supplier_no == msgModel.Body.supplierNo
                                 select q).AsNoTracking();
                    int count = query.Count();
                    if (!string.IsNullOrWhiteSpace(msgModel.Body.goodsNo))
                        query = query.Where(it => it.goodsNo == msgModel.Body.goodsNo).AsNoTracking();
                    if (!string.IsNullOrWhiteSpace(msgModel.Body.goodsName))
                        query = query.Where(it => it.goodsName.Contains(msgModel.Body.goodsName)).AsNoTracking();
                    jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(new { total = count, rows = query.OrderBy(it => it.spid).Skip((msgModel.Body.pageNo - 1) * msgModel.Body.pageSize).Take(msgModel.Body.pageSize) }) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }

            return jr;
        }
        /// <summary>
        ///查询供应商信息 按照 qry_type 查询 
        /// {"Action":"qry_supplier","Key":"TG0001","Time":"2017-08-22","Body":{"supplierNo":"051","goodsName":"小糖医","qry_type":"4"}}
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult qry_supplier(PostMessage.BiwQryData msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || msgModel.Body.qryType <= 0)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty or qryType equal or less than 0.");
                return jr;
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    var query = (from q in dbContext.biw_suppliergoods
                                 select new
                                 {
                                     q.supplier_id,
                                     q.supplier_no,
                                     q.supplier_name,
                                     q.rshtqx,
                                     q.isjh,
                                     q.jsfs
                                 }).AsNoTracking();
                    switch (msgModel.Body.qryType)
                    {
                        case 1:
                            if (string.IsNullOrWhiteSpace(msgModel.Body.supplierNo))
                                jr.Data = new ResultMessage.ParamError() { Body = "Type " + msgModel.Body.qryType + " need param supplierNo." };
                            else
                                query = query.Where(it => it.supplier_no == msgModel.Body.supplierNo).AsNoTracking().Distinct();
                            break;
                        case 2:
                            if (string.IsNullOrWhiteSpace(msgModel.Body.goodsNo))
                                jr.Data = new ResultMessage.ParamError() { Body = "Type " + msgModel.Body.qryType + " need param goodsNo." };
                            else
                                query = (from q in dbContext.biw_suppliergoods
                                         where q.goodsNo == msgModel.Body.goodsNo
                                         select new
                                         {
                                             q.supplier_id,
                                             q.supplier_no,
                                             q.supplier_name,
                                             q.rshtqx,
                                             q.isjh,
                                             q.jsfs
                                         }).AsNoTracking().Distinct();
                            break;
                        case 3:
                            if (string.IsNullOrWhiteSpace(msgModel.Body.supplierName))
                                jr.Data = new ResultMessage.ParamError() { Body = "Type " + msgModel.Body.qryType + " need param supplierName." };
                            else
                                query = query.Where(it => it.supplier_name.Contains(msgModel.Body.supplierName)).AsNoTracking().Distinct();
                            break;
                        case 4:
                            if (string.IsNullOrWhiteSpace(msgModel.Body.goodsName))
                                jr.Data = new ResultMessage.ParamError() { Body = "Type " + msgModel.Body.qryType + " need param goodsName." };
                            else
                                query = (from q in dbContext.biw_suppliergoods
                                         where q.goodsName.Contains(msgModel.Body.goodsName)
                                         select new
                                         {
                                             q.supplier_id,
                                             q.supplier_no,
                                             q.supplier_name,
                                             q.rshtqx,
                                             q.isjh,
                                             q.jsfs
                                         }).AsNoTracking().Distinct();
                            break;
                        default:
                            jr.Data = new ResultMessage.ParamError() { Body = "Unknown param value of 'qry_type'" };
                            break;
                    }
                    if (jr.Data == null)
                        jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(query) };

                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }
            return jr;
        }
        /// <summary>
        /// 商品分类查询 按等级 或 分类编号(需要修改识图名称)
        /// {"Action":"qry_category","Key":"TG0001","Time":"2017-08-22","Body":{"level":"3","category_no":"101"}}
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult qry_category(PostMessage.BiwQryGoodsCategory msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null || msgModel.Body == null || string.IsNullOrWhiteSpace(msgModel.Body.level))
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty or Level is Null Or whiteSpace.");
                return jr;
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    if ((msgModel.Body.level.Equals("2") || msgModel.Body.level.Equals("3")) && string.IsNullOrWhiteSpace(msgModel.Body.category_no))
                    {
                        jr.Data = new ResultMessage.ParamError() { Body = "CategoryNo can not be null when level is 2 or 3 " };
                        return jr;
                    }
                    var query = (from q in dbContext.biw_category
                                 where q.level == msgModel.Body.level
                                 select q).AsNoTracking();
                    if (!string.IsNullOrWhiteSpace(msgModel.Body.category_no))
                        query = query.Where(it => it.category_no.Contains(msgModel.Body.category_no));
                    jr.Data = new ResultMessage.Successed() { Body = JsonConvert.SerializeObject(query) };
                }
            }
            catch (Exception e1)
            {
                while (e1.InnerException != null && e1.Message.Contains("See the inner exception"))
                    e1 = e1.InnerException;
                jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                Logger.WriteLog(e1.Message);
                Logger.WriteLog("Body Data:" + JsonConvert.SerializeObject(msgModel.Body));
                return jr;
            }

            return jr;
        }
    }
}

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
        #region Header + Body(String) Mode Common Accept
        //[HttpPost]
        //public JsonResult Biw(Biw_PostMsgModel msgModel)
        //{
        //    JsonResult jr = new JsonResult();
        //    jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

        //    if (msgModel == null)
        //    {
        //        jr.Data = new ResultMessage.HaveNoData();
        //        return jr;
        //    }


        //    switch (msgModel.Action)
        //    {
        //        case MessageId.SaveReturnPo:
        //            break;
        //            //return saveReturnPo(msgModel.Body);

        //        default:break;
        //    }

        //    return jr;
        //}
        #endregion
        [HttpPost]
        public JsonResult saveReturnPo(PostMessage.saveReturnPo msgModel) 
         {

            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            KSOANoModel result=null;
            if (msgModel == null)
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
                    jr.Data = new ResultMessage.ProcError() { Message = e1.Message };
                    Logger.WriteLog(e1.Message);
                    Logger.WriteLog("Body Data:" + jsr.Serialize(msgModel.Body));
                    return jr;
                }
            }
            jr.Data = new ResultMessage.Successed() {Body=jsr.Serialize(result) };
            return jr;
        }
        [HttpPost]
        public JsonResult priceMaSaveBatch(PostMessage.priceMaSaveBatch msgModel)
        {
            JsonResult jr = new JsonResult();
            jr.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            if (msgModel == null)
            {
                jr.Data = new ResultMessage.HaveNoData();
                Logger.WriteLog("Model is empty.");
                return jr;
            }
            List<priceMa> saveList = new List<priceMa>();
            List<Biw_PriceMaBiwMModel> postList=msgModel.Body;
            string gzid;
            Random random=new Random();
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
                        saveList.Add(priceMaKsoaModel);

                    }
                    //saveList.Clear();
                }
            }
            try
            {
                using (BIW_KSOAContext dbContext = new BIW_KSOAContext())
                {
                    dbContext.priceMas.AddRange(saveList);
                    dbContext.SaveChanges();
                    jr.Data = new ResultMessage.Successed();
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
            return jr;
        }

    }
}

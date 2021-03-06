﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHDS.Entities.Edmx;

namespace PHDS.Web.Controllers
{
    public class SalesController : BaseController
    {
        public ActionResult Index()
        {
            using (var pinhua = new PinhuaEntities())
            {
                var customers = from p in pinhua.往来单位.AsNoTracking()
                               orderby p.RANK descending
                               select new
                               {
                                   p.单位编号,
                                   p.单位名称,
                               };
                var CustomerList = new List<SelectListItem>();
                foreach(var customer in customers)
                {
                    CustomerList.Add(new SelectListItem { Text = customer.单位编号, Value = customer.单位名称 });
                }
                ViewBag.CustomerList = CustomerList;
                var set = from p in pinhua.发货.AsNoTracking()
                          select new Models.SalesModels.OrdersModel
                          {
                              rcId = p.ExcelServerRCID,
                              orderId = p.送货单号,
                              customerId = p.客户编号,
                              customerName = p.客户,
                              stockoutDate = p.送货日期.Value,
                              customerAddress = p.地址,
                              stockoutType = p.业务类型,
                              stockoutTypeDescription = p.业务描述,
                          };

                return View(set.ToList());
            }
        }

        [HttpPost]
        public ActionResult 删除单据(string rcid)
        {
            using (var pinhua = new PinhuaEntities())
            {
                int delCount = 0;
                foreach (var p in (from p in pinhua.ES_RepCase where p.rcId == rcid select p))
                {
                    pinhua.ES_RepCase.Remove(p);
                    delCount++;
                }
                foreach (var p in (from p in pinhua.发货 where p.ExcelServerRCID == rcid select p))
                {
                    pinhua.发货.Remove(p);
                    delCount++;
                }
                foreach (var p in (from p in pinhua.发货_DETAIL where p.ExcelServerRCID == rcid select p))
                {
                    pinhua.发货_DETAIL.Remove(p);
                    delCount++;
                }
                using (var trans = pinhua.Database.BeginTransaction())
                {
                    var realCount = pinhua.SaveChanges();

                    if (realCount == delCount)
                        trans.Commit();
                    else
                        trans.Rollback();

                    return new EmptyResult();
                }
            }
        }
        
        public ActionResult 保存单据(PHDS.Web.Models.SalesModels.OrderDetailModel model)
        {
            System.Diagnostics.Debug.WriteLine(model.Description);
            return new EmptyResult();
        }
    }
}

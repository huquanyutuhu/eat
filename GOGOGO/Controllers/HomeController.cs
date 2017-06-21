using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOGOGO.BLL;
using Newtonsoft.Json;

namespace GOGOGO.Controllers
{
    [CheckLogin]
    public class HomeController : Controller
    {
        public string UserName = "";
        public ActionResult Index()
        {
            try
            {
                UserName = Session["UserName"].ToString();
            }
            catch (Exception)
            {
            }
            return View();
        }

        [HttpPost]
        public JsonResult IndexJsonResult(string shopName)
        {
            return Json(new {Shops= MenuBll.GetMenus(shopName) ,Today = MenuBll.GetTodayMenus()} ,JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult IndexAddTodayJsonResult(string userName, string name, double price)
        {
            return Json(MenuBll.AddTodayMenus(UserName = Session["UserName"].ToString(), name, price));
        }

        [HttpPost]
        public JsonResult IndexGetTodayJsonResult()
        {
            return Json(MenuBll.GetTodayMenus());
        }
        [HttpPost]
        public JsonResult IndexGetAvgPrice(int counts)
        {
            return Json(MenuBll.GetAvgPrice(counts));
        }
    }
}
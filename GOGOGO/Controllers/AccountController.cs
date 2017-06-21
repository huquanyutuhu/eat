using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using GOGOGO.BLL;
using GOGOGO.Commons;

namespace GOGOGO.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public string Register(string username,string password)
        {
            return UserBll.AddUser(username, password);
        }

        public ActionResult Logion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logion(string userName, string password)
        {
            if (UserBll.GetUsers().Any(x => x.UserName==userName && x.Password == password))
            {
                Session["IsLogin"] = true;
                Session["UserName"] = userName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Logion");
            }
        }
    }
}
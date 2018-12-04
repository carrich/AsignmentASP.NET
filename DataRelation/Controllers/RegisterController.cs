using DataRelation.DAL;
using DataRelation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataRelation.Controllers
{
    public class RegisterController : Controller
    {
        private OrderContext db = new OrderContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SaveData(User model)
        {
            db.Users.Add(model);
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckValidUser(User model)
        {
            string result = "Fail";
            var DataItem = db.Users.Where(x => x.Email == model.Email && x.Password == model.Password).SingleOrDefault();
            if (DataItem != null)
            {
                User user = new User();
                user.ID = DataItem.ID;
                user.Username = DataItem.Username;
                
                Session["User"] = user;
                
                result = "Success";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AfterLogin()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}
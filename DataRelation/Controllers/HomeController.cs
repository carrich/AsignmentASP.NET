using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRelation.DAL;
using DataRelation.Models;

namespace DataRelation.Controllers
{
    public class HomeController : Controller
    {
        private OrderContext db = new OrderContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UploadImage()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public ActionResult UploadImage(ImageFile objImage)
        {
            foreach (var file in objImage.files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    User user = (User)Session["User"];
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string filePath = "~/Uploads/" + fileName;
                    string DatePosted = DateTime.Now.ToString("yymmssfff");
                    Random rnd = new Random();
                    int fileId = rnd.Next(1, 100);
                    Image image = new Image();
                    image.Id = fileId;
                    image.Name = fileName;
                    image.Path = filePath;
                    image.DatePosted = DateTime.Now;
                    image.UserID = user.ID;
                    db.Images.Add(image);
                    db.SaveChanges();

                    file.SaveAs(Path.Combine(Server.MapPath("/Uploads"), fileName));
                }
            }
            return View();
        }
        public class ImageFile
        {
            public List<HttpPostedFileBase> files { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataRelation.DAL;
using DataRelation.Models;

namespace DataRelation.Controllers
{
    public class ItemsController : Controller
    {
        private OrderContext db = new OrderContext();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Material).Include(i => i.Size);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create(int id)
        {
            Image image = db.Images.Find(id);
            ViewBag.MaterialId = new SelectList(db.materials, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name");
            ViewBag.PathImage = image.Path;
            
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaterialId,SizeId,PathImage,Quantity")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                if (Session["cart"] == null)
                {
                    List<Item> cart = new List<Item>();
                    cart.Add(new Item(item.Id,item.PathImage,item.Quantity,db.materials.Find(item.MaterialId),db.Sizes.Find(item.SizeId)));
                    Session["cart"] = cart;
                }
                else
                {
                    List<Item> cart = (List<Item>)Session["cart"];
                    cart.Add(new Item(item.Id,item.PathImage, item.Quantity, db.materials.Find(item.MaterialId), db.Sizes.Find(item.SizeId) ));
                }
                   
                return RedirectToAction("Cart");
            }


            ViewBag.MaterialId = new SelectList(db.materials, "Id", "Name", item.MaterialId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", item.SizeId);
            return View(item);
        }

        public ActionResult Cart()
        {
            return View();
        }
        
        public ActionResult Delete1(int id)
        {
            
            List<Item> cart = (List<Item>)Session["cart"];
           
            
                cart.RemoveAt(id);
            

            Session["cart"] = cart;
            return RedirectToAction("Cart");
        }
        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialId = new SelectList(db.materials, "Id", "Name", item.MaterialId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", item.SizeId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaterialId,SizeId,PathImage")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialId = new SelectList(db.materials, "Id", "Name", item.MaterialId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", item.SizeId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

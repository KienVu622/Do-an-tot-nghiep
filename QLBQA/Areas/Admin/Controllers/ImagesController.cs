using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBQA.Models;

namespace QLBQA.Areas.Admin.Controllers
{
    public class ImagesController : Controller
    {
        private QLBQA_DB db = new QLBQA_DB();

        // GET: Admin/Images
        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Product);
            return View(images.ToList());
        }

        // GET: Admin/Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Admin/Images/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: Admin/Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageID,Description,ProductID")] Image image, IEnumerable<HttpPostedFileBase> ImageFiles)
        {
            if (ModelState.IsValid)
            {
                if (ImageFiles != null && ImageFiles.Count() > 0)
                {
                    foreach (var file in ImageFiles)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            string FileName = System.IO.Path.GetFileName(file.FileName);
                            string UploadPath = Server.MapPath("~/Content/images/" + image.ProductID + "_" + FileName);
                            file.SaveAs(UploadPath);

                            // Tạo mới đối tượng Image và lưu thông tin vào csdl
                            Image newImage = new Image();
                            newImage.Path = FileName;
                            newImage.Description = image.Description;
                            newImage.ProductID = image.ProductID;
                            db.Images.Add(newImage);
                        }
                    }
                    db.SaveChanges();
                }
                int productId = image.ProductID;
                string productName = image.Product.ProductName;

                TempData["ProductId"] = productId;
                TempData["ProductName"] = productName;
                return RedirectToAction("Create", "ProductDetails");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", image.ProductID);
            return View(image);
        }


        // GET: Admin/Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", image.ProductID);
            return View(image);
        }

        // POST: Admin/Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageID,Path,Description,ProductID")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", image.ProductID);
            return View(image);
        }

        // GET: Admin/Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Admin/Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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

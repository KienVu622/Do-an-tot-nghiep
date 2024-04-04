using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBQA.Models;

namespace QLBQA.Controllers
{
    public class ProductController : Controller
    {

        private  QLBQA_DB db = new QLBQA_DB();

      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductID == id);

            // Kiểm tra nếu sản phẩm không tồn tại
            if (product == null)
            {
                return HttpNotFound(); // Trả về lỗi 404 Not Found
            }

            // Trả về view hiển thị chi tiết sản phẩm
            return View(product);
        }

    }
}
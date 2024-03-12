using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebNangcao.Controllers
{
    public class LoginController : Controller
    {
        Models.QuanLyKomboEntities db = new Models.QuanLyKomboEntities();
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.KhachHang obj)
        {
            if (ModelState.IsValid)
            {
                Models.KhachHang check = db.KhachHangs.FirstOrDefault(m => m.Email == obj.Email && m.Pass == obj.Pass);
                if (check == null)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");

                }
                else
                {
                    Session["KhachHang"] = check;
                        return RedirectToAction("Index", "Home", new { area = "" }
);
                }
            }
            return View(obj);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebNangcao.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        Models.QuanLyKomboEntities db = new Models.QuanLyKomboEntities();
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(Models.DangNhap obj)
        {
            if (ModelState.IsValid)
            {
                Models.DangNhap check = db.DangNhaps.FirstOrDefault(m => m.TaiKhoan == obj.TaiKhoan && m.MatKhau == obj.MatKhau);
                if (check == null)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(check.TaiKhoan, false);
                    if (Request.QueryString["ReturnUrl"] == null || Request.QueryString["ReturnUrl"] == "")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(Request.QueryString["ReturnUrl"]);
                    }

                    
                }
            }
            return View(obj);
        }

       public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebNangcao.Controllers
{

    public class CartController : Controller

    {
        WebNangcao.Models.QuanLyKomboEntities db = new Models.QuanLyKomboEntities();

        // GET: Cart

        private double Tongsoluong()
        {
            double Tongsoluong = 0;
            List<Models.CartModel> lstCart = Session["Cart"] as List<Models.CartModel>;
            if (lstCart != null)
            {
                Tongsoluong = lstCart.Sum(m => m.quantity);
            }
            return Tongsoluong;
        }

        private double Tongtien()
        {
            double Tongtien = 0;
            List<Models.CartModel> lstCart = Session["Cart"] as List<Models.CartModel>;
            if (lstCart != null)
            {
                Tongtien = lstCart.Sum(m => m.amount);
            }
            return Tongtien;
        }
        public ActionResult Index()
        {
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien=Tongtien();
            if (Session["KhachHang"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
                return View();
        }

        public ActionResult Cart(int Id)
        {
            Models.SanPham obj = db.SanPhams.FirstOrDefault(m => m.Id == Id);

            if (obj != null)
            {
                List<Models.CartModel> lstCart = null;

                if (Session["Cart"] == null)
                {
                    lstCart = new List<Models.CartModel>();
                }
                else
                {
                    lstCart = (List<Models.CartModel>)Session["Cart"];
                }

                Models.CartModel check = lstCart.FirstOrDefault(m => m.productId == Id);

                if (check == null)
                {
                    lstCart.Add(new Models.CartModel
                    {
                        productId = Id,
                        ProductDetail = obj,
                        quantity = 1,
                        amount = (double)(1 * obj.DonGia),
                    });
                }
                else
                {
                    check.quantity = check.quantity + 1;
                    check.amount = (double)(check.quantity * check.ProductDetail.DonGia);
                }

                Session["Cart"] = lstCart;
            }

            return RedirectToAction("Index");
        }


        public ActionResult Xoa(int Id)
        {
            List<Models.CartModel> cart = Session["Cart"]as List<Models.CartModel>;
            Models.CartModel xoa = cart.FirstOrDefault(m => m.productId == Id);
            if(xoa!=null)
            {
                cart.Remove(xoa);   
            }
            return RedirectToAction("Index", new { productId = Id });
        }
    }

}

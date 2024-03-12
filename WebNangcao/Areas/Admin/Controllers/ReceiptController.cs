using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNangcao.Models;

namespace WebNangcao.Areas.Admin.Controllers
{
    [Authorize]
    public class ReceiptController : Controller
    {
        Models.QuanLyKomboEntities db=new Models.QuanLyKomboEntities();
        // GET: Admin/Receipt
        public ActionResult Index()
        {
            List<Models.HoaDon> data = db.HoaDons.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            ViewBag.ChiTietHDId = new SelectList(db.HoaDons, "Id", "");
            ViewBag.KhachHangId = new SelectList(db.HoaDons, "Id", "TenKH");
            return View();
        }
        [HttpPost]
        public ActionResult Create (Models.HoaDon obj) 
        {
                try
                {
                    db.HoaDons.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {

                }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            Models.HoaDon obj= db.HoaDons.Find(id);
            ViewBag.ChiTietHDId = new SelectList(db.HoaDons, "Id", "NULL");
            ViewBag.KhachHangId = new SelectList(db.HoaDons, "Id", "TenKH");
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(Models.HoaDon obj) 
        {
            try
            {
                Models.HoaDon crrobj = db.HoaDons.Find(obj.Id);
                crrobj.Thue = obj.Thue;
                crrobj.MoTa=obj.MoTa;
                crrobj.DiaChi= obj.DiaChi; 
                crrobj.TongTien=obj.TongTien;
                crrobj.NgayBan=obj.NgayBan;
                crrobj.KhachHangId=obj.KhachHangId;
                crrobj.ChiTietHDId=obj.ChiTietHDId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Delete(int Id) 
        {
            Models.HoaDon obj = db.HoaDons.Find(Id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int Id)
        {
            try
            {
                Models.HoaDon obj = db.HoaDons.Find(Id);
                if (obj != null)
                {
                    db.HoaDons.Remove(obj);
                    db.SaveChanges();
                }
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

    }
}
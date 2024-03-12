using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebNangcao.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        Models.QuanLyKomboEntities db = new Models.QuanLyKomboEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            List<Models.SanPham> data = db.SanPhams.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DanhMucId = new SelectList(db.DanhMucs.ToList(), "Id", "TenDanhMuc");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.SanPham obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var anh = Request.Files["anh"];
                    if (anh != null && anh.ContentLength > 0)
                    {
                        string fanh = anh.FileName;
                        string folder = Server.MapPath("~/Asset/Image/" + fanh);
                        anh.SaveAs(folder);
                        obj.Anh = "/Asset/Image/" + fanh;
                    }
                    db.SanPhams.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {

                }
            }
            ViewBag.DanhMucId = new SelectList(db.DanhMucs.ToList(), "Id", "TenDanhMuc");
            return View(obj);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Models.SanPham obj = db.SanPhams.Find(Id);
            ViewBag.DanhMucId = new SelectList(db.DanhMucs, "Id", "TenDanhMuc");
            return View(obj);
        }

        [HttpPost]

        public ActionResult Edit(Models.SanPham obj)
        {
            try
            {
                Models.SanPham crrobj = db.SanPhams.Find(obj.Id);
                var anh = Request.Files["anh"];
                if (anh != null && anh.ContentLength > 0)
                {
                    string fanh = anh.FileName;
                    string folder = Server.MapPath("~/Asset/Image/" + fanh);
                    anh.SaveAs(folder);
                    obj.Anh = "/Asset/Image/" + fanh;
                }
                crrobj.Anh= obj.Anh;
                crrobj.TenSP = obj.TenSP;
                crrobj.DanhMucId = obj.DanhMucId;   
                crrobj.DonGia = obj.DonGia;
                crrobj.NgayBan = obj.NgayBan;
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
            Models.SanPham obj = db.SanPhams.Find(Id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int Id)
        {
            try
            {
                Models.SanPham obj = db.SanPhams.Find(Id);
                if (obj != null)
                {
                    db.SanPhams.Remove(obj);
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
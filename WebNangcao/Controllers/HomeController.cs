using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNangcao.Models;

namespace WebNangcao.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        Models.QuanLyKomboEntities db = new Models.QuanLyKomboEntities();
        public ActionResult Index()
        {
            
            var listMenu = db.SanPhams.Include("DanhMuc").ToList();
            var listDanhMuc =  db.DanhMucs.ToList();
            ViewBag.ListDanhMuc = listDanhMuc;

            return View(listMenu);
           
        }
        
        public ActionResult About()
        {
            List<Models.SanPham> sameProduct = db.SanPhams.Take(6).OrderBy(m => m.Id).ToList();
            ViewBag.sameProduct = sameProduct;
            
            return View();
        }


        public ActionResult Detail(int Id)
        {
            List<Models.SanPham> sameProduct = db.SanPhams.Take(4).OrderByDescending(m => m.Id).ToList();
            ViewBag.sameProduct = sameProduct;

            SanPham pro = db.SanPhams.FirstOrDefault(row => row.Id == Id);

            return View(pro);
        }



    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pnthanh_k22cntt_2210900066_prj2.Models;

namespace pnthanh_k22cntt_2210900066_prj2.Controllers
{
    public class GioHangsController : Controller
    {
        private pnthanh_k22cntt_2210900066Entities db = new pnthanh_k22cntt_2210900066Entities();

        // GET: GioHangs
        public ActionResult Index()
        {
            var gioHang = db.GioHang.Include(g => g.KhachHang).Include(g => g.SanPham);
            return View(gioHang.ToList());
        }

        // GET: GioHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHang.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // GET: GioHangs/Create
        public ActionResult Create()
        {
            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "tenKhachHang");
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham");
            return View();
        }

        // POST: GioHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idKhachHang,idSanPham,soLuong")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.GioHang.Add(gioHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "tenKhachHang", gioHang.idKhachHang);
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", gioHang.idSanPham);
            return View(gioHang);
        }

        // GET: GioHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHang.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "tenKhachHang", gioHang.idKhachHang);
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", gioHang.idSanPham);
            return View(gioHang);
        }

        // POST: GioHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idKhachHang,idSanPham,soLuong")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gioHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idKhachHang = new SelectList(db.KhachHang, "id", "tenKhachHang", gioHang.idKhachHang);
            ViewBag.idSanPham = new SelectList(db.SanPham, "id", "tenSanPham", gioHang.idSanPham);
            return View(gioHang);
        }

        // GET: GioHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHang.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // POST: GioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GioHang gioHang = db.GioHang.Find(id);
            db.GioHang.Remove(gioHang);
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

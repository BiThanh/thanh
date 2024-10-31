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
    public class ThanhToansController : Controller
    {
        private pnthanh_k22cntt_2210900066Entities db = new pnthanh_k22cntt_2210900066Entities();

        // GET: ThanhToans
        public ActionResult Index()
        {
            var thanhToan = db.ThanhToan.Include(t => t.DonHang);
            return View(thanhToan.ToList());
        }

        // GET: ThanhToans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToan.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }

        // GET: ThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.idDonHang = new SelectList(db.DonHang, "id", "trangThai");
            return View();
        }

        // POST: ThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idDonHang,idPhuongThucThanhToan,ngayThanhToan,soTien")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.ThanhToan.Add(thanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDonHang = new SelectList(db.DonHang, "id", "trangThai", thanhToan.idDonHang);
            return View(thanhToan);
        }

        // GET: ThanhToans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToan.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDonHang = new SelectList(db.DonHang, "id", "trangThai", thanhToan.idDonHang);
            return View(thanhToan);
        }

        // POST: ThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idDonHang,idPhuongThucThanhToan,ngayThanhToan,soTien")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDonHang = new SelectList(db.DonHang, "id", "trangThai", thanhToan.idDonHang);
            return View(thanhToan);
        }

        // GET: ThanhToans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToan.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }

        // POST: ThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThanhToan thanhToan = db.ThanhToan.Find(id);
            db.ThanhToan.Remove(thanhToan);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarrMIS4200.DAL;
using CarrMIS4200.Models;

namespace CarrMIS4200.Controllers
{
    public class AppointmentsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointment = db.Appointment.Include(a => a.Doctor).Include(a => a.Patient);
            return View(appointment.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.doctorId = new SelectList(db.Doctor, "doctorId", "fullName");
            ViewBag.patientId = new SelectList(db.Patient, "patientId", "fullName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "appointmentId,appointmentDate,doctorId,patientId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointment.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctorId = new SelectList(db.Doctor, "doctorId", "fullName", appointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patient, "patientId", "fullName", appointment.patientId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctorId = new SelectList(db.Doctor, "doctorId", "docLastName", appointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patient, "patientId", "patientLastName", appointment.patientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "appointmentId,appointmentDate,doctorId,patientId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctorId = new SelectList(db.Doctor, "doctorId", "fullName", appointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patient, "patientId", "fullName", appointment.patientId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointment.Find(id);
            db.Appointment.Remove(appointment);
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

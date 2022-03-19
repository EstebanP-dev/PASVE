using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PASVE.Models;

namespace PASVE.Controllers
{
    public class CareersController : Controller
    {
        private PASVEEntities db = new PASVEEntities();

        // GET: Careers
        public async Task<ActionResult> Index()
        {
            var careers = db.Careers.Include(c => c.Department);
            return View(await careers.ToListAsync());
        }

        // GET: Careers/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = await db.Careers.FindAsync(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        // GET: Careers/Create
        public ActionResult Create()
        {
            ViewBag.fk_Departmet = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Careers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CreditValue,TotalCredits,fk_Departmet,Active")] Career career)
        {
            if (ModelState.IsValid)
            {
                career.Id = Guid.NewGuid();
                db.SP_CAREERS_INSERT(career.Name, career.CreditValue, career.TotalCredits, career.fk_Departmet, career.Active);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.fk_Departmet = new SelectList(db.Departments, "Id", "Name", career.fk_Departmet);
            return View(career);
        }

        // GET: Careers/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = await db.Careers.FindAsync(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_Departmet = new SelectList(db.Departments, "Id", "Name", career.fk_Departmet);
            return View(career);
        }

        // POST: Careers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CreditValue,TotalCredits,fk_Departmet,Active")] Career career)
        {
            if (ModelState.IsValid)
            {
               db.SP_CAREERS_UPDATE(career.Id, career.Name, career.CreditValue, career.TotalCredits, career.fk_Departmet, career.Active);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.fk_Departmet = new SelectList(db.Departments, "Id", "Name", career.fk_Departmet);
            return View(career);
        }

        // GET: Careers/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = await db.Careers.FindAsync(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        // POST: Careers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            db.SP_CAREERS_DELETE(id);
            await db.SaveChangesAsync();
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

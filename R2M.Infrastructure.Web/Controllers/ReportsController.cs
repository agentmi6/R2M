using Microsoft.AspNet.Identity;
using R2M.Domain;
using R2M.Domain.RepositoryInterfaces;
using R2M.Infrastructure.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace R2M.Infrastructure.Web.Controllers
{
    public class ReportsController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        IRepository<Report> reportRepo = new ReportRepository();

        // GET: Reports
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            return View(reportRepo.GetAll().Where(x=>x.ApplicationUserID == currentUser));
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DeptName");
            return View();
        }

        // POST: Reports/Create
        [HttpPost]
        public ActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                report.ApplicationUserID = User.Identity.GetUserId();               
                reportRepo.Create(report);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DeptName", report.DepartmentID);
            return View();
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DeptName", report.DepartmentID);
            return View(report);
        }

        // POST: Reports/Edit/5
        [HttpPost]
        public ActionResult Edit(Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = System.Data.Entity.EntityState.Modified;                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DeptName", report.DepartmentID);
            return View();
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost]
        public ActionResult Delete(Report report)
        {
            reportRepo.Delete(report.ID);
            return RedirectToAction("Index");
        }
    }
}

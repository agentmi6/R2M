using R2M.Domain;
using R2M.Domain.RepositoryInterfaces;
using R2M.Infrastructure.Data;
using System.Net;
using System.Web.Mvc;

namespace R2M.Infrastructure.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        IRepository<Department> deptRepo = new DepartmentRepository();

        // GET: Departments
        public ActionResult Index()
        {
            return View(deptRepo.GetAll());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dept = db.Departments.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        public ActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                deptRepo.Create(dept);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dept = db.Departments.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        public ActionResult Edit(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department dept = db.Departments.Find(id);
            if (dept == null)
            {
                return HttpNotFound();
            }
            return View(dept);
        }

        // POST: Departments/Delete/5
        [HttpPost]
        public ActionResult Delete(Department dept)
        {
            deptRepo.Delete(dept.ID);
            return RedirectToAction("Index"); 
        }
    }
}

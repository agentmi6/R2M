using R2M.Domain;
using R2M.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2M.Infrastructure.Data
{
    public class DepartmentRepository : IRepository<Department>
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public void Create(Department entity)
        {
            db.Departments.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var dept = db.Departments.Find(id);
            db.Departments.Remove(dept);
            db.SaveChanges();
        }

    }
}

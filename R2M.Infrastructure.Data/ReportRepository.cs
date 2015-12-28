using R2M.Domain;
using R2M.Domain.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;


namespace R2M.Infrastructure.Data
{
    public class ReportRepository : IRepository<Report>
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Report> GetAll()
        {            
            return db.Reports.ToList();
        }
        public void Create(Report entity)
        {
            db.Reports.Add(entity);
            db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var report = db.Reports.Find(id);
            db.Reports.Remove(report);
            db.SaveChanges();
        }

    }
}

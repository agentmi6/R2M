using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2M.Domain
{
    public class Report : BaseEntity
    {        
        public string DailyReport { get; set; }        
        public DateTime DateCreated { get; set; }


        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

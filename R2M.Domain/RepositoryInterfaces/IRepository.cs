using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2M.Domain.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Create(T entity);
        void Delete(int id);
    }
}

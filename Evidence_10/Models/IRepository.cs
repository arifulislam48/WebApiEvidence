using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_10.Models
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> getAll();
        T get(int id);
        T create(T vm);
        bool remove(int id);
        T update(T vm);
    }
}

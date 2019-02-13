using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Entities;
using VapeApp.DAL.Entities;

namespace Vape.DAL.Interfaces
{
    public interface IRepository<T>  where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);

        IEnumerable<T> GetImage(int id);

        void Create(T item);
        void Update(T item);


        void Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Entities;
using Vape.DAL.Interfaces;
using VapeApp.DAL.EF;
using VapeApp.DAL.Entities;

namespace Vape.DAL.Repositories
{
    public class TankRepository : IRepository<Tank>
    {
        private VapeContext db;

        public TankRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Tank> GetAll()
        {
            return db.Tanks;
        }

        public Tank Get(int id)
        {
            return db.Tanks.Find(id);
        }

        public void Create(Tank book)
        {
            db.Tanks.Add(book);
        }

        public void Update(Tank book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Tank> Find(Func<Tank, Boolean> predicate)
        {
            return db.Tanks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Tank book = db.Tanks.Find(id);
            if (book != null)
                db.Tanks.Remove(book);
        }

        #region
 

        public IEnumerable<Tank> FindBoxMod(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllBoxMod()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tank> GetImage(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

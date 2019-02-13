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
    public class DripRepository : IRepository<Drip>
    {
        private VapeContext db;

        public DripRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Drip> GetAll()
        {
            return db.Drips;
        }

        public Drip Get(int id)
        {
            return db.Drips.Find(id);
        }

        public void Create(Drip book)
        {
            db.Drips.Add(book);
        }

        public void Update(Drip book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Drip> Find(Func<Drip, Boolean> predicate)
        {
            return db.Drips.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Drip book = db.Drips.Find(id);
            if (book != null)
                db.Drips.Remove(book);
        }

        #region
        public IEnumerable<Image> GetFullVape(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Drip> FindBoxMod(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllBoxMod()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Drip> IRepository<Drip>.GetImage(int id)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}

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
    public class BoxModRepository : IRepository<BoxMod>
    {
        private VapeContext db;

        public BoxModRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<BoxMod> GetAll()
        {
            return db.BoxMods;
        }

        public BoxMod Get(int id)
        {
            return db.BoxMods.Find(id);
        }

        public void Create(BoxMod book)
        {
            db.BoxMods.Add(book);
        }

        public void Update(BoxMod book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<BoxMod> Find(Func<BoxMod, Boolean> predicate)
        {
            return db.BoxMods.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            BoxMod book = db.BoxMods.Find(id);
            if (book != null)
                db.BoxMods.Remove(book);
        }

        #region

        public IEnumerable<BoxMod> FindBoxMod(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllBoxMod()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BoxMod> GetImage(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

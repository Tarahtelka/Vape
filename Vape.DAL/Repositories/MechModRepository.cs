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
    public class MechModRepository : IRepository<MechMod>
    {
        private VapeContext db;

        public MechModRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<MechMod> GetAll()
        {
            return db.MechMods;
        }

        public MechMod Get(int id)
        {
            return db.MechMods.Find(id);
        }

        public void Create(MechMod book)
        {
            db.MechMods.Add(book);
        }

        public void Update(MechMod book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<MechMod> Find(Func<MechMod, Boolean> predicate)
        {
            return db.MechMods.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            MechMod book = db.MechMods.Find(id);
            if (book != null)
                db.MechMods.Remove(book);
        }

        #region
  

        public IEnumerable<MechMod> FindBoxMod(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllBoxMod()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MechMod> GetImage(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

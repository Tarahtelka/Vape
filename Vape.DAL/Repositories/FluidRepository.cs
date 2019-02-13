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
    public class FluidRepository : IRepository<Fluid>
    {
        private VapeContext db;

        public FluidRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Fluid> GetAll()
        {
            return db.Fluids;
        }

        public Fluid Get(int id)
        {
            return db.Fluids.Find(id);
        }

        public void Create(Fluid book)
        {
            db.Fluids.Add(book);
        }

        public void Update(Fluid book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Fluid> Find(Func<Fluid, Boolean> predicate)
        {
            return db.Fluids.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Fluid book = db.Fluids.Find(id);
            if (book != null)
                db.Fluids.Remove(book);
        }

        #region



        public IEnumerable<Fluid> FindBoxMod(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllBoxMod()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fluid> GetImage(int id)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}

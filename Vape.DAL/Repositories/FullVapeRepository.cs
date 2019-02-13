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
    public class FullVapeRepository : IRepository<FullVape>
    {
        private VapeContext db;

        public FullVapeRepository (VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<FullVape> GetAll()
        {
            return db.FullVapes;
        }

        public FullVape Get(int id)
        {
            return db.FullVapes.Find(id);
        }

        public void Create(FullVape fullVape)
        {
            db.FullVapes.Add(fullVape);
        }

        public void Update(FullVape fullVape)
        {

            db.Entry(fullVape).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<FullVape> Find(Func<FullVape, Boolean> predicate)
        {
            return db.FullVapes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            FullVape fullVape = db.FullVapes.Find(id);
            if (fullVape != null)
                db.FullVapes.Remove(fullVape);
        }

        #region
        
        public IEnumerable<FullVape> GetImage(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

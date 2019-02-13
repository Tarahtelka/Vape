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
    public class ImageRepository : IRepository<Image>
    {
        private VapeContext db;

        public ImageRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Image> GetAll()
        {
            return db.Images.Include(o => o.FullVape);
        }

        public Image Get(int id)
        {
            return db.Images.Find(id);
        }

        public void Create(Image image)
        {
            db.Images.Add(image);
        }

        public IEnumerable<Image> GetImage(int id)//////
        {                                      
            return db.Images.Where(x => x.FullVapeId == id);
        }

        public void Update(Image image)
        {
            db.Entry(image).State = EntityState.Modified;
        }

        public IEnumerable<Image> Find(Func<Image, Boolean> predicate)
        {
            return db.Images.Include(o => o.FullVape).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Image image = db.Images.Find(id);
            if (image != null)
                db.Images.Remove(image);
        }
#region


#endregion
    }

}


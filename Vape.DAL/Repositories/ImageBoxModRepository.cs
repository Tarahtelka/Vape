using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Entities;
using Vape.DAL.Interfaces;
using VapeApp.DAL.EF;

namespace Vape.DAL.Repositories
{
    public class ImageBoxModRepository : IRepository<ImageBoxMod>
    {
        private VapeContext db;

        public ImageBoxModRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<ImageBoxMod> GetAll()
        {
            return db.ImageBoxMods.Include(o => o.BoxMod);
        }

        public ImageBoxMod Get(int id)
        {
            return db.ImageBoxMods.Find(id);
        }

        public void Create(ImageBoxMod image)
        {
            db.ImageBoxMods.Add(image);
        }

        public IEnumerable<ImageBoxMod> GetImage(int id)//////
        {
            return db.ImageBoxMods.Where(x => x.BoxModId == id);
        }

        public void Update(ImageBoxMod image)
        {
            db.Entry(image).State = EntityState.Modified;
        }

        public IEnumerable<ImageBoxMod> Find(Func<ImageBoxMod, Boolean> predicate)
        {
            return db.ImageBoxMods.Include(o => o.BoxMod).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ImageBoxMod image = db.ImageBoxMods.Find(id);
            if (image != null)
                db.ImageBoxMods.Remove(image);
        }
    }
}

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
    public class ImageMechModRepository : IRepository<ImageMechMod>
    {
        private VapeContext db;

        public ImageMechModRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<ImageMechMod> GetAll()
        {
            return db.ImageMechMods.Include(o => o.MechMod);
        }

        public ImageMechMod Get(int id)
        {
            return db.ImageMechMods.Find(id);
        }

        public void Create(ImageMechMod image)
        {
            db.ImageMechMods.Add(image);
        }

        public IEnumerable<ImageMechMod> GetImage(int id)//////
        {
            return db.ImageMechMods.Where(x => x.MechModID == id);
        }

        public void Update(ImageMechMod image)
        {
            db.Entry(image).State = EntityState.Modified;
        }

        public IEnumerable<ImageMechMod> Find(Func<ImageMechMod, Boolean> predicate)
        {
            return db.ImageMechMods.Include(o => o.MechMod).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ImageMechMod image = db.ImageMechMods.Find(id);
            if (image != null)
                db.ImageMechMods.Remove(image);
        }
    }
}

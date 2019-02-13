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
    public class ImageDripRepository : IRepository<ImageDrip>
    {
        private VapeContext db;

        public ImageDripRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<ImageDrip> GetAll()
        {
            return db.ImageDrips.Include(o => o.Drip);
        }

        public ImageDrip Get(int id)
        {
            return db.ImageDrips.Find(id);
        }

        public void Create(ImageDrip image)
        {
            db.ImageDrips.Add(image);
        }

        public IEnumerable<ImageDrip> GetImage(int id)//////
        {
            return db.ImageDrips.Where(x => x.DripID == id);
        }

        public void Update(ImageDrip image)
        {
            db.Entry(image).State = EntityState.Modified;
        }

        public IEnumerable<ImageDrip> Find(Func<ImageDrip, Boolean> predicate)
        {
            return db.ImageDrips.Include(o => o.Drip).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ImageDrip image = db.ImageDrips.Find(id);
            if (image != null)
                db.ImageDrips.Remove(image);
        }
    }
}

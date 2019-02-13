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
    public class ImageFluidRepository : IRepository<ImageFluid>
    {
        private VapeContext db;

        public ImageFluidRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<ImageFluid> GetAll()
        {
            return db.ImageFluids.Include(o => o.Fluid);
        }

        public ImageFluid Get(int id)
        {
            return db.ImageFluids.Find(id);
        }

        public void Create(ImageFluid image)
        {
            db.ImageFluids.Add(image);
        }

        public IEnumerable<ImageFluid> GetImage(int id)//////
        {
            return db.ImageFluids.Where(x => x.FluidID == id);
        }

        public void Update(ImageFluid image)
        {
            db.Entry(image).State = EntityState.Modified;
        }

        public IEnumerable<ImageFluid> Find(Func<ImageFluid, Boolean> predicate)
        {
            return db.ImageFluids.Include(o => o.Fluid).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ImageFluid image = db.ImageFluids.Find(id);
            if (image != null)
                db.ImageFluids.Remove(image);
        }
    }
}

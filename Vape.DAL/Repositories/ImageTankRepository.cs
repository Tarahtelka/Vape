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
    public class ImageTankRepository : IRepository<ImageTank>
    {
        private VapeContext db;

        public ImageTankRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<ImageTank> GetAll()
        {
            return db.ImageTanks.Include(o => o.Tank);
        }

        public ImageTank Get(int id)
        {
            return db.ImageTanks.Find(id);
        }

        public void Create(ImageTank image)
        {
            db.ImageTanks.Add(image);
        }

        public IEnumerable<ImageTank> GetImage(int id)//////
        {
            return db.ImageTanks.Where(x => x.TankID == id);
        }

        public void Update(ImageTank image)
        {
            db.Entry(image).State = EntityState.Modified;
        }

        public IEnumerable<ImageTank> Find(Func<ImageTank, Boolean> predicate)
        {
            return db.ImageTanks.Include(o => o.Tank).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ImageTank image = db.ImageTanks.Find(id);
            if (image != null)
                db.ImageTanks.Remove(image);
        }
    }
}

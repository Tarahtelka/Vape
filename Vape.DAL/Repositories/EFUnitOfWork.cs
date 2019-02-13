using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Entities;
using Vape.DAL.Identity;
using Vape.DAL.Interfaces;
using VapeApp.DAL.EF;
using VapeApp.DAL.Entities;

namespace Vape.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private VapeContext db;
        private BoxModRepository boxModRepository;
        private DripRepository dripRepository;
        private FluidRepository fluidRepository;
        private FullVapeRepository fullVapeRepository;
        private MechModRepository mechModRepository;
        private TankRepository tankRepository;
        private OrderRepository orderRepository;

        private ImageDripRepository imageDripRepository;
        private ImageFluidRepository imageFluidRepository;
        private ImageMechModRepository imageMechModRepository;
        private ImageTankRepository imageTankRepository;
        private ImageBoxModRepository imageBoxModRepository;
        private ImageRepository imageRepository;


        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public EFUnitOfWork(string connectionString)
        {
            db = new VapeContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public IRepository<BoxMod> BoxMods
        {
            get
            {
                if (boxModRepository == null)
                    boxModRepository = new BoxModRepository(db);
                return boxModRepository;
            }
        }

        public IRepository<Drip> Drips
        {
            get
            {
                if (dripRepository == null)
                    dripRepository = new DripRepository(db);
                return dripRepository;
            }
        }

        public IRepository<Fluid> Fluids
        {
            get
            {
                if (fluidRepository == null)
                    fluidRepository = new FluidRepository(db);
                return fluidRepository;
            }
        }

        public IRepository<FullVape> FullVapes
        {
            get
            {
                if (fullVapeRepository == null)
                    fullVapeRepository = new FullVapeRepository(db);
                return fullVapeRepository;
            }
        }

        public IRepository<MechMod> MechMods
        {
            get
            {
                if (mechModRepository == null)
                    mechModRepository = new MechModRepository(db);
                return mechModRepository;
            }
        }

        public IRepository<Tank> Tanks
        {
            get
            {
                if (tankRepository == null)
                    tankRepository = new TankRepository(db);
                return tankRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IRepository<Image> Images
        {
        
            get
            {
                
                if (imageRepository == null)
                    imageRepository = new ImageRepository(db);
                return imageRepository;
            }
        }

        public IRepository<ImageBoxMod> ImageBoxMods
        {
            get
            {

                if (imageBoxModRepository == null)
                    imageBoxModRepository = new ImageBoxModRepository(db);
                return imageBoxModRepository;
            }
        }

        public IRepository<ImageDrip> ImageDrips
        {
            get
            {

                if (imageDripRepository == null)
                    imageDripRepository = new ImageDripRepository(db);
                return imageDripRepository;
            }
        }

        public IRepository<ImageFluid> ImageFluids
        {
            get
            {

                if (imageFluidRepository == null)
                    imageFluidRepository = new ImageFluidRepository(db);
                return imageFluidRepository;
            }
        }

        public IRepository<ImageMechMod> ImageMechMods
        {
            get
            {

                if (imageMechModRepository == null)
                    imageMechModRepository = new ImageMechModRepository(db);
                return imageMechModRepository;
            }
        }

        public IRepository<ImageTank> ImageTanks
        {
            get
            {

                if (imageTankRepository == null)
                    imageTankRepository = new ImageTankRepository(db);
                return imageTankRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();

                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

    }
}

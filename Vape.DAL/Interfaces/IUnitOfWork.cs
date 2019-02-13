using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Entities;
using Vape.DAL.Identity;
using VapeApp.DAL.Entities;

namespace Vape.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Tank> Tanks { get; }
        IRepository<MechMod> MechMods { get; }
        IRepository<FullVape> FullVapes { get; }
        IRepository<Fluid> Fluids { get; }
        IRepository<Drip> Drips { get; }
        IRepository<BoxMod> BoxMods { get; }
        IRepository<Order> Orders { get; }
        IRepository<ImageFluid> ImageFluids { get;  }
        IRepository<ImageDrip> ImageDrips { get;  }
        IRepository<ImageMechMod> ImageMechMods { get; }
        IRepository<ImageTank> ImageTanks { get; }
        IRepository<ImageBoxMod> ImageBoxMods { get; }
        IRepository<Image> Images { get; }
        void Save();
        void Dispose();

        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}

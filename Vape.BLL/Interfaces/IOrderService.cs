using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;

namespace Vape.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrderBoxMod(OrderDTO orderDto);

        void MakeOrderDrip(OrderDTO orderDto);

        void MakeOrderFluid(OrderDTO orderDto);

        void MakeOrderFullVape(OrderDTO orderDto);

        void MakeOrderMechMod(OrderDTO orderDto);

        void MakeOrderTank(OrderDTO orderDto);

        BoxModDTO GetBoxMod(int? id);
        IEnumerable<BoxModDTO> GetBoxMods();

        DripDTO GetDrip(int? id);
        IEnumerable<DripDTO> GetDrips();

        FluidDTO GetFluid(int? id);
        IEnumerable<FluidDTO> GetFluids();

        FullVapeDTO GetFullVape(int? id);
        IEnumerable<FullVapeDTO> GetFullVapes();

        MechModDTO GetMechMod(int? id);
        IEnumerable<MechModDTO> GetMechMods();

        TankDTO GetTank(int? id);
        IEnumerable<TankDTO> GetTanks();

        void AddFullVape(FullVapeDTO fullvapeDto);

        void UpdateFullVape(FullVapeDTO fullvapeDto);

        void DeleteFullVape(int id);

        void AddBoxMod(BoxModDTO boxModDto);

        void UpdateBoxMod(BoxModDTO boxModDto);

        void DeleteBoxMod(int id);

        void UpdateDrip(DripDTO dripDto);

        void AddDrip(DripDTO dripDto);

        void DeleteDrip(int id);

        void AddMechMod(MechModDTO mechModDto);

        void UpdateMechMod(MechModDTO mechModDto);

        void DeleteMechMod(int id);

        void AddTank(TankDTO tankDto);

        void UpdateTank(TankDTO tankDto);

        void DeleteTank(int id);

        void UpdateFluid(FluidDTO fluidDto);

        void AddFluid(FluidDTO fluidDto);

        void DeleteFluid(int id);

        void Dispose();
    }
}

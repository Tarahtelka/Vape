using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.BusinessModels;
using Vape.BLL.DTO;
using Vape.BLL.Infrastructure;
using Vape.BLL.Interfaces;
using Vape.DAL.Interfaces;
using VapeApp.DAL.Entities;

namespace Vape.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrderBoxMod(OrderDTO orderDto)
        {
            BoxMod boxMod = Database.BoxMods.Get(orderDto.BoxModId);

            // валидация
            if (boxMod == null)
                throw new ValidationException("BoxMod не найден", "");
            decimal sum = boxMod.Price;
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                BoxModId = boxMod.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public IEnumerable<BoxModDTO> GetBoxMods()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg => cfg.CreateMap<BoxMod, BoxModDTO>());
            return Mapper.Map<IEnumerable<BoxMod>, List<BoxModDTO>>(Database.BoxMods.GetAll());
        }
        public BoxModDTO GetBoxMod(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id BoxMod", "");
            var boxMod = Database.BoxMods.Get(id.Value);
            if (boxMod == null)
                throw new ValidationException("BoxMod не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<BoxMod, BoxModDTO>());
            return Mapper.Map<BoxMod, BoxModDTO>(boxMod);
        }

        public void MakeOrderDrip(OrderDTO orderDto)
        {
            Drip drip = Database.Drips.Get(orderDto.DripId);

            // валидация
            if (drip == null)
                throw new ValidationException("Drip не найден", "");
            decimal sum = drip.Price;
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                DripId = drip.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public IEnumerable<DripDTO> GetDrips()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Drip, DripDTO>());
            return Mapper.Map<IEnumerable<Drip>, List<DripDTO>>(Database.Drips.GetAll());
        }
        public DripDTO GetDrip(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Drip", "");
            var drip = Database.Drips.Get(id.Value);
            if (drip == null)
                throw new ValidationException("Drip не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Drip, DripDTO>());
            return Mapper.Map<Drip, DripDTO>(drip);
        }

        public void MakeOrderFluid(OrderDTO orderDto)
        {
            Fluid fluid = Database.Fluids.Get(orderDto.FluidId);

            // валидация
            if (fluid == null)
                throw new ValidationException("Fluid не найден", "");
            decimal sum = fluid.Price;
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                FluidId = fluid.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public IEnumerable<FluidDTO> GetFluids()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Fluid, FluidDTO>());
            return Mapper.Map<IEnumerable<Fluid>, List<FluidDTO>>(Database.Fluids.GetAll());
        }
        public FluidDTO GetFluid(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Fluid", "");
            var fluid = Database.Fluids.Get(id.Value);
            if (fluid == null)
                throw new ValidationException("Fluid не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Fluid, FluidDTO>());
            return Mapper.Map<Fluid, FluidDTO>(fluid);
        }

        public void MakeOrderFullVape(OrderDTO orderDto)
        {
            FullVape fullVape = Database.FullVapes.Get(orderDto.FullVapeId);

            // валидация
            if (fullVape == null)
                throw new ValidationException("FullVape не найден", "");
            decimal sum = fullVape.Price;
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                FullVapeId = fullVape.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public IEnumerable<FullVapeDTO> GetFullVapes()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<FullVape, FullVapeDTO>());
            return Mapper.Map<IEnumerable<FullVape>, List<FullVapeDTO>>(Database.FullVapes.GetAll());
        }
        public FullVapeDTO GetFullVape(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id FullVape", "");
            var fullVape = Database.FullVapes.Get(id.Value);
            if (fullVape == null)
                throw new ValidationException("FullVape не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<FullVape, FullVapeDTO>());
            return Mapper.Map<FullVape, FullVapeDTO>(fullVape);
        }

        public void MakeOrderMechMod(OrderDTO orderDto)
        {
            MechMod mechMod = Database.MechMods.Get(orderDto.MechModId);

            // валидация
            if (mechMod == null)
                throw new ValidationException("MechMod не найден", "");
            decimal sum = mechMod.Price;
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                MechModId = mechMod.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public IEnumerable<MechModDTO> GetMechMods()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<MechMod, MechModDTO>());
            return Mapper.Map<IEnumerable<MechMod>, List<MechModDTO>>(Database.MechMods.GetAll());
        }
        public MechModDTO GetMechMod(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id MechMod", "");
            var mechMod = Database.MechMods.Get(id.Value);
            if (mechMod == null)
                throw new ValidationException("MechMod не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<MechMod, MechModDTO>());
            return Mapper.Map<MechMod, MechModDTO>(mechMod);
        }

        public void MakeOrderTank(OrderDTO orderDto)
        {
            Tank tank = Database.Tanks.Get(orderDto.TankId);

            // валидация
            if (tank == null)
                throw new ValidationException("Tank не найден", "");
            decimal sum = tank.Price;
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                TankId = tank.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public IEnumerable<TankDTO> GetTanks()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Tank, TankDTO>());
            return Mapper.Map<IEnumerable<Tank>, List<TankDTO>>(Database.Tanks.GetAll());
        }
        public TankDTO GetTank(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Tank", "");
            var tank = Database.Tanks.Get(id.Value);
            if (tank == null)
                throw new ValidationException("Tank не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Tank, TankDTO>());
            return Mapper.Map<Tank, TankDTO>(tank);
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public void AddFullVape(FullVapeDTO fullVapeDto)
        {
            FullVape fullVape = new FullVape
            {
                Name = fullVapeDto.Name,
                Company = fullVapeDto.Company,
                Accumulator = fullVapeDto.Accumulator,
                Brand = fullVapeDto.Brand,
                Amount = fullVapeDto.Amount,
                Contry = fullVapeDto.Contry,
                Outturn = fullVapeDto.Outturn,
                Price = fullVapeDto.Price,
            };
            Database.FullVapes.Create(fullVape);
            Database.Save();
        }
        public void DeleteFullVape(int id)
        {
            Database.FullVapes.Delete(id);
            Database.Save();
        }

        public void AddBoxMod(BoxModDTO boxModDto)
        {
            BoxMod boxMod = new BoxMod
            {
                Name = boxModDto.Name,
                Company = boxModDto.Company,
                Accumulator = boxModDto.Accumulator,
                Brand = boxModDto.Brand,
                Amount = boxModDto.Amount,
                Contry = boxModDto.Contry,
                Outturn = boxModDto.Outturn,
                Price = boxModDto.Price,
            };
            Database.BoxMods.Create(boxMod);
            Database.Save();
        }
        public void DeleteBoxMod(int id)
        {
            Database.BoxMods.Delete(id);
            Database.Save();
        }

        public void AddDrip(DripDTO dripDto)
        {
            Drip drip = new Drip
            {
                Name = dripDto.Name,
                Company = dripDto.Company,
                Diameter = dripDto.Diameter,
                Brand = dripDto.Brand,
                Racks = dripDto.Racks,
                Contry = dripDto.Contry,
                Price = dripDto.Price,
            };
            Database.Drips.Create(drip);
            Database.Save();
        }
        public void DeleteDrip(int id)
        {
            Database.Drips.Delete(id);
            Database.Save();
        }

        public void AddMechMod(MechModDTO mechModDto)
        {
            MechMod mechMod = new MechMod
            {
                Name = mechModDto.Name,
                Company = mechModDto.Company,
                Accumulator = mechModDto.Accumulator,
                Brand = mechModDto.Brand,
                Racks = mechModDto.Racks,
                Contry = mechModDto.Contry,
                Price = mechModDto.Price,
                Outturn = mechModDto.Outturn,
                TypeButton = mechModDto.TypeButton,
            };
            Database.MechMods.Create(mechMod);
            Database.Save();
        }
        public void DeleteMechMod(int id)
        {
            Database.MechMods.Delete(id);
            Database.Save();
        }

        public void AddTank(TankDTO tankDto)
        {
            Tank tank = new Tank
            {
                Name = tankDto.Name,
                Company = tankDto.Company,
                Amount = tankDto.Amount,
                Brand = tankDto.Brand,
                Racks = tankDto.Racks,
                Contry = tankDto.Contry,
                Price = tankDto.Price,
                Diameter = tankDto.Diameter,
            };
            Database.Tanks.Create(tank);
            Database.Save();
        }
        public void DeleteTank(int id)
        {
            Database.Tanks.Delete(id);
            Database.Save();
        }

        public void AddFluid(FluidDTO fluidDto)
        {
            Fluid fluid = new Fluid
            {
                Name = fluidDto.Name,
                Company = fluidDto.Company,
                PG = fluidDto.PG,
                Brand = fluidDto.Brand,
                Flavor = fluidDto.Flavor,
                Contry = fluidDto.Contry,
                Price = fluidDto.Price,
                VG = fluidDto.VG,
            };

            Database.Fluids.Create(fluid);
            Database.Save();
        }
        public void DeleteFluid(int id)
        {
            Database.Fluids.Delete(id);
            Database.Save();
        }
        public void UpdateFullVape(FullVapeDTO fullVapeDto)
        {
            FullVape fullVape = new FullVape
            {
                Id = fullVapeDto.Id,
                Name = fullVapeDto.Name,
                Company = fullVapeDto.Company,
                Accumulator = fullVapeDto.Accumulator,
                Brand = fullVapeDto.Brand,
                Amount = fullVapeDto.Amount,
                Contry = fullVapeDto.Contry,
                Outturn = fullVapeDto.Outturn,
                Price = fullVapeDto.Price,
            };
            Database.FullVapes.Update(fullVape);
            Database.Save();
        }

        public void UpdateBoxMod(BoxModDTO boxModDto)
        {
            BoxMod boxMod = new BoxMod
            {
                Id = boxModDto.Id,
                Name = boxModDto.Name,
                Company = boxModDto.Company,
                Accumulator = boxModDto.Accumulator,
                Brand = boxModDto.Brand,
                Amount = boxModDto.Amount,
                Contry = boxModDto.Contry,
                Outturn = boxModDto.Outturn,
                Price = boxModDto.Price,
            };
            Database.BoxMods.Update(boxMod);
            Database.Save();
        }

        public void UpdateDrip(DripDTO dripDto)
        {
            Drip drip = new Drip
            {
                Id = dripDto.Id,
                Name = dripDto.Name,
                Company = dripDto.Company,
                Diameter = dripDto.Diameter,
                Brand = dripDto.Brand,
                Racks = dripDto.Racks,
                Contry = dripDto.Contry,
                Price = dripDto.Price,
            };
            Database.Drips.Update(drip);
            Database.Save();
        }

        public void UpdateMechMod(MechModDTO mechModDto)
        {
            MechMod mechMod = new MechMod
            {
                Id = mechModDto.Id,
                Name = mechModDto.Name,
                Company = mechModDto.Company,
                Accumulator = mechModDto.Accumulator,
                Brand = mechModDto.Brand,
                Racks = mechModDto.Racks,
                Contry = mechModDto.Contry,
                Price = mechModDto.Price,
                Outturn = mechModDto.Outturn,
                TypeButton = mechModDto.TypeButton,
            };
            Database.MechMods.Update(mechMod);
            Database.Save();
        }

        public void UpdateTank(TankDTO tankDto)
        {
            Tank tank = new Tank
            {
                Id = tankDto.Id,
                Name = tankDto.Name,
                Company = tankDto.Company,
                Amount = tankDto.Amount,
                Brand = tankDto.Brand,
                Racks = tankDto.Racks,
                Contry = tankDto.Contry,
                Price = tankDto.Price,
                Diameter = tankDto.Diameter,
            };
            Database.Tanks.Update(tank);
            Database.Save();
        }

        public void UpdateFluid(FluidDTO fluidDto)
        {
            Fluid fluid = new Fluid
            {
                Id = fluidDto.Id,
                Name = fluidDto.Name,
                Company = fluidDto.Company,
                PG = fluidDto.PG,
                Brand = fluidDto.Brand,
                Flavor = fluidDto.Flavor,
                Contry = fluidDto.Contry,
                Price = fluidDto.Price,
                VG = fluidDto.VG,
            };

            Database.Fluids.Update(fluid);
            Database.Save();
        }
    }
}

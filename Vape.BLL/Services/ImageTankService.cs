using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;
using Vape.BLL.Infrastructure;
using Vape.BLL.Interfaces;
using Vape.DAL.Entities;
using Vape.DAL.Interfaces;
using VapeApp.DAL.Entities;
namespace Vape.BLL.Services
{
    public class ImageTankService : IImageTankService
    {
        IUnitOfWork Database { get; set; }

        public ImageTankService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ImageTankDTO> GetImgTanks(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ImageTank, ImageTankDTO>());
            return Mapper.Map<IEnumerable<ImageTank>, List<ImageTankDTO>>(Database.ImageTanks.GetImage(id));
        }

        public void Add(ImageTankDTO imageTankDto)
        {
            Tank tank = Database.Tanks.Get(imageTankDto.TankId);

            // валидация
            if (tank == null)
                throw new ValidationException("Tank не найден", "");
            ImageTank imageTank = new ImageTank
            {
                Data = imageTankDto.Data,
                MimeType = imageTankDto.MimeType,
                TankID = tank.Id,
            };
            Database.ImageTanks.Create(imageTank);
            Database.Save();
        }

        public ImageTankDTO GetImg(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Tank", "");
            var img = Database.ImageTanks.Get(id.Value);
            if (img == null)
                throw new ValidationException("Tank не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageTank, ImageTankDTO>());
            return Mapper.Map<ImageTank, ImageTankDTO>(img);
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

        public IEnumerable<ImageTankDTO> GetImages(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Tank", "");
            var img = Database.ImageTanks.Get(id.Value);
            if (img == null)
                throw new ValidationException("Tank не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageTank, ImageTankDTO>());
            return Mapper.Map<IEnumerable<ImageTank>, List<ImageTankDTO>>(Database.ImageTanks.GetAll());
        }

        public void DeleteImgTank(int id)
        {
            Database.ImageTanks.Delete(id);
            Database.Save();
        }
    }
}

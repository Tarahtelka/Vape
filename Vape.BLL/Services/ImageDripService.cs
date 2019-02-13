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
    public class ImageDripService : IImageDripService
    {
        IUnitOfWork Database { get; set; }

        public ImageDripService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ImageDripDTO> GetImgDrips(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDrip, ImageDripDTO>());
            return Mapper.Map<IEnumerable<ImageDrip>, List<ImageDripDTO>>(Database.ImageDrips.GetImage(id));
        }

        public void Add(ImageDripDTO imageDripDto)
        {
            Drip drip = Database.Drips.Get(imageDripDto.DripId);

            // валидация
            if (drip == null)
                throw new ValidationException("Drip не найден", "");
            ImageDrip imageDrip = new ImageDrip
            {
                Data = imageDripDto.Data,
                MimeType = imageDripDto.MimeType,
                DripID = drip.Id,
            };
            Database.ImageDrips.Create(imageDrip);
            Database.Save();
        }

        public ImageDripDTO GetImg(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Drip", "");
            var img = Database.ImageDrips.Get(id.Value);
            if (img == null)
                throw new ValidationException("Drip не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDrip, ImageDripDTO>());
            return Mapper.Map<ImageDrip, ImageDripDTO>(img);
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

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ImageDripDTO> GetImages(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Drip", "");
            var img = Database.ImageDrips.Get(id.Value);
            if (img == null)
                throw new ValidationException("Drip не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageDrip, ImageDripDTO>());
            return Mapper.Map<IEnumerable<ImageDrip>, List<ImageDripDTO>>(Database.ImageDrips.GetAll());
        }

        public void DeleteImgDrip(int id)
        {
            Database.ImageDrips.Delete(id);
            Database.Save();
        }
    }
}

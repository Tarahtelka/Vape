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
    public class ImageBoxModService : IImageBoxModService
    {
        IUnitOfWork Database { get; set; }

        public ImageBoxModService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ImageBoxModDTO> GetImgBoxMods(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ImageBoxMod, ImageBoxModDTO>());
            return Mapper.Map<IEnumerable<ImageBoxMod>, List<ImageBoxModDTO>>(Database.ImageBoxMods.GetImage(id));
        }

        public void Add(ImageBoxModDTO imageBoxModDto)
        {
            BoxMod boxMod = Database.BoxMods.Get(imageBoxModDto.BoxModId);

            // валидация
            if (boxMod == null)
                throw new ValidationException("FullVape не найден", "");
            ImageBoxMod imageBoxMod = new ImageBoxMod
            {
                Data = imageBoxModDto.Data,
                MimeType = imageBoxModDto.MimeType,
                BoxModId = boxMod.Id,
            };
            Database.ImageBoxMods.Create(imageBoxMod);
            Database.Save();
        }

        public ImageBoxModDTO GetImg(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id BoxMod", "");
            var img = Database.ImageBoxMods.Get(id.Value);
            if (img == null)
                throw new ValidationException("BoxMod не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageBoxMod, ImageBoxModDTO>());
            return Mapper.Map<ImageBoxMod, ImageBoxModDTO>(img);
        }

        public IEnumerable<BoxModDTO> GetBoxMods()
        {
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

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ImageBoxModDTO> GetImages(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Image", "");
            var img = Database.ImageBoxMods.Get(id.Value);
            if (img == null)
                throw new ValidationException("Image не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageBoxMod, ImageBoxModDTO>());
            return Mapper.Map<IEnumerable<ImageBoxMod>, List<ImageBoxModDTO>>(Database.ImageBoxMods.GetAll());
        }

        public void DeleteImgBoxMod(int id)
        {
            Database.ImageBoxMods.Delete(id);
            Database.Save();
        }
    }
}

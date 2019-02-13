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
    public class ImageMechModService : IImageMechModService
    {
        IUnitOfWork Database { get; set; }

        public ImageMechModService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ImageMechModDTO> GetImgMechMods(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ImageMechMod, ImageMechModDTO>());
            return Mapper.Map<IEnumerable<ImageMechMod>, List<ImageMechModDTO>>(Database.ImageMechMods.GetImage(id));
        }

        public void Add(ImageMechModDTO imageMechModDto)
        {
            MechMod mechMod = Database.MechMods.Get(imageMechModDto.MechModId);

            // валидация
            if (mechMod == null)
                throw new ValidationException("MechMod не найден", "");
            ImageMechMod imageMechMod = new ImageMechMod
            {
                Data = imageMechModDto.Data,
                MimeType = imageMechModDto.MimeType,
                MechModID = mechMod.Id,
            };
            Database.ImageMechMods.Create(imageMechMod);
            Database.Save();
        }

        public ImageMechModDTO GetImg(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id MechMod", "");
            var img = Database.ImageMechMods.Get(id.Value);
            if (img == null)
                throw new ValidationException("MechMod не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageMechMod, ImageMechModDTO>());
            return Mapper.Map<ImageMechMod, ImageMechModDTO>(img);
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

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ImageMechModDTO> GetImages(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id MechMod", "");
            var img = Database.ImageMechMods.Get(id.Value);
            if (img == null)
                throw new ValidationException("MechMod не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageMechMod, ImageMechModDTO>());
            return Mapper.Map<IEnumerable<ImageMechMod>, List<ImageMechModDTO>>(Database.ImageMechMods.GetAll());
        }

        public void DeleteImgMechMod(int id)
        {
            Database.ImageMechMods.Delete(id);
            Database.Save();
        }
    }
}

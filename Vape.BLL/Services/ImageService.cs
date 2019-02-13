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
    public class ImageService : IImageService
    {
        IUnitOfWork Database { get; set; }

        public ImageService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ImageDTO> GetImgFullVapes(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Image, ImageDTO>());
            return Mapper.Map<IEnumerable<Image>, List<ImageDTO>>(Database.Images.GetImage(id));
        }

        public void Add(ImageDTO imageDto)
        {
            FullVape fullVape = Database.FullVapes.Get(imageDto.FullVapeId);

            // валидация
            if (fullVape == null)
                throw new ValidationException("FullVape не найден", "");
            Image image = new Image
            {
                Data = imageDto.Data,
                MimeType = imageDto.MimeType,
                FullVapeId = fullVape.Id,
            };
            Database.Images.Create(image);
            Database.Save();
        }

        public ImageDTO GetImg(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id FullVape", "");
            var img = Database.Images.Get(id.Value);
            if (img == null)
                throw new ValidationException("FullVape не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Image, ImageDTO>());
            return Mapper.Map<Image, ImageDTO>(img);
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

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ImageDTO> GetImages(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Image", "");
            var img = Database.Images.Get(id.Value);
            if (img == null)
                throw new ValidationException("Image не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Image, ImageDTO>());
            return Mapper.Map<IEnumerable<Image>, List<ImageDTO>>(Database.Images.GetAll());
        }
        public void DeleteImgFullVape(int id)
        {
            Database.Images.Delete(id);
            Database.Save();
        }
    }
}

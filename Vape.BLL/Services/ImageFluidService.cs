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
    public class ImageFluidService : IImageFluidService
    {
        IUnitOfWork Database { get; set; }

        public ImageFluidService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ImageFluidDTO> GetImgFluids(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ImageFluid, ImageFluidDTO>());
            return Mapper.Map<IEnumerable<ImageFluid>, List<ImageFluidDTO>>(Database.ImageFluids.GetImage(id));
        }

        public void Add(ImageFluidDTO imageFluidDto)
        {
            Fluid fluid = Database.Fluids.Get(imageFluidDto.FluidId);

            // валидация
            if (fluid == null)
                throw new ValidationException("Fluid не найден", "");
            ImageFluid imageFluid = new ImageFluid
            {
                Data = imageFluidDto.Data,
                MimeType = imageFluidDto.MimeType,
                FluidID = fluid.Id,
            };
            Database.ImageFluids.Create(imageFluid);
            Database.Save();
        }

        public ImageFluidDTO GetImg(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Fluid", "");
            var img = Database.ImageFluids.Get(id.Value);
            if (img == null)
                throw new ValidationException("Fluid не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageFluid, ImageFluidDTO>());
            return Mapper.Map<ImageFluid, ImageFluidDTO>(img);
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

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ImageFluidDTO> GetImages(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Fluid", "");
            var img = Database.ImageFluids.Get(id.Value);
            if (img == null)
                throw new ValidationException("Fluid не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<ImageFluid, ImageFluidDTO>());
            return Mapper.Map<IEnumerable<ImageFluid>, List<ImageFluidDTO>>(Database.ImageFluids.GetAll());
        }

        public void DeleteImgFluid(int id)
        {
            Database.ImageFluids.Delete(id);
            Database.Save();
        }
    }
}

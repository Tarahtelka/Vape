using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vape.BLL.DTO;
using Vape.BLL.Infrastructure;
using Vape.BLL.Interfaces;
using VapeApp.WEB.Models;
using System.Web.Helpers;
using System.IO;
using Vape.DAL.Entities;

namespace VapeApp.WEB.Controllers
{
    public class FluidController : Controller
    {
        IOrderService orderService;
        IImageFluidService imageFluidService;
        public FluidController(IOrderService serv, IImageFluidService imageFluidserv)
        {
            orderService = serv;
            imageFluidService = imageFluidserv;
        }

        public ActionResult Admin()
        {
            IEnumerable<FluidDTO> fluidDtos = orderService.GetFluids();
            Mapper.Initialize(cfg => cfg.CreateMap<FluidDTO, FluidViewModel>());
            var fluid = Mapper.Map<IEnumerable<FluidDTO>, List<FluidViewModel>>(fluidDtos);

            return View(fluid);
        }

        public ActionResult DeleteFluid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteFluid(int id)
        {

            orderService.DeleteFluid(id);
            return View("View");
        }

        public ActionResult DeleteImgFluid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteImgFluid(int id)
        {

            imageFluidService.DeleteImgFluid(id);
            return View("View");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FluidViewModel FluidViewModel)
        {

            if (ModelState.IsValid)
            {
                FluidDTO fluidDto = new FluidDTO
                {
                    Name = FluidViewModel.Name,
                    Company = FluidViewModel.Company,
                    PG = FluidViewModel.PG,
                    Brand = FluidViewModel.Brand,
                    VG = FluidViewModel.VG,
                    Contry = FluidViewModel.Contry,
                    Flavor = FluidViewModel.Flavor,
                    Price = FluidViewModel.Price,
                };
                orderService.AddFluid(fluidDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult Update(int id)
        {
            FluidDTO fluidDto = orderService.GetFluid(id);
            Mapper.Initialize(cfg => cfg.CreateMap<FluidDTO, FluidViewModel>());
            var fluid = Mapper.Map<FluidDTO, FluidViewModel>(fluidDto);
            return View(fluid);
        }

        [HttpPost]
        public ActionResult Update(FluidViewModel fluidViewModel)
        {

            if (ModelState.IsValid)
            {
                FluidDTO FluidDto = new FluidDTO
                {
                    Id = fluidViewModel.Id,
                    Name = fluidViewModel.Name,
                    Company = fluidViewModel.Company,
                    PG = fluidViewModel.PG,
                    Brand = fluidViewModel.Brand,
                    VG = fluidViewModel.VG,
                    Contry = fluidViewModel.Contry,
                    Flavor = fluidViewModel.Flavor,
                    Price = fluidViewModel.Price,
                };
                orderService.UpdateFluid(FluidDto);
                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult Index()
        {
            IEnumerable<FluidDTO> fluidDtos = orderService.GetFluids();
            Mapper.Initialize(cfg => cfg.CreateMap<FluidDTO, FluidViewModel>());
            var fluid = Mapper.Map<IEnumerable<FluidDTO>, List<FluidViewModel>>(fluidDtos);
            return View(fluid);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadImage, int id)
        {
            FluidDTO fluidDto = imageFluidService.GetFluid(id);

            if (ModelState.IsValid && fluidDto != null)
            {
                ImageFluidDTO image = new ImageFluidDTO
                {
                    FluidId = id,
                    MimeType = uploadImage.ContentType,
                };
                image.Data = new byte[uploadImage.ContentLength];
                uploadImage.InputStream.Read(image.Data, 0, uploadImage.ContentLength);
                imageFluidService.Add(image);

                return View("View");
            }
            else
            {
                return View("View1");
            }
        }

        public ActionResult GetImgFluid(int id)
        {
            IEnumerable<ImageFluidDTO> imageFluidDTO = imageFluidService.GetImgFluids(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageFluidDTO, ImageFluidViewModel>());
            var img = Mapper.Map<IEnumerable<ImageFluidDTO>, List<ImageFluidViewModel>>(imageFluidDTO);
            return View(img);
        }

        public ActionResult GetImgFluidAdmin(int id)
        {
            IEnumerable<ImageFluidDTO> imageFluidDTO = imageFluidService.GetImgFluids(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageFluidDTO, ImageFluidViewModel>());
            var img = Mapper.Map<IEnumerable<ImageFluidDTO>, List<ImageFluidViewModel>>(imageFluidDTO);
            return View(img);
        }

        public FileResult GetFile(int id)
        {
            ImageFluidDTO imgFluidDto = imageFluidService.GetImg(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ImageFluidDTO, ImageFluidViewModel>());
            var img = Mapper.Map<ImageFluidDTO, ImageFluidViewModel>(imgFluidDto);
            return File(img.Data, img.MimeType);
        }

        public ActionResult GetFluid(int id)
        {
            FluidDTO fluidDto = orderService.GetFluid(id);
            Mapper.Initialize(cfg => cfg.CreateMap<FluidDTO, FluidViewModel>());
            var fluid = Mapper.Map<FluidDTO, FluidViewModel>(fluidDto);
            return View(fluid);
        }
    }
}